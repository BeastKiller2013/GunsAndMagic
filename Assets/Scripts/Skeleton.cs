﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
	Rigidbody rb;

	AIState state = AIState.idle;

	Animator anim;

	ParticleSystem fireAttackPart;
	ParticleSystem.EmissionModule em;

	bool lockedState = false;

	float attackCountdown = 2f;
	float attackDelay = 2f;

	NavMeshAgent nav;

	public GameObject target;

	ConeCollider collCone;

	float damageDelay = .5f;
	float damageCountDown = .5f;


    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
		collCone = transform.Find("cone").GetComponent<ConeCollider>();
		state = AIState.idle;
		fireAttackPart = transform.Find("FireBall").GetComponent<ParticleSystem>();
		em = fireAttackPart.emission;
		em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

		if(Input.GetKey(KeyCode.A) && !lockedState)
		{
			state = AIState.attacking;
		}

		if (Input.GetKey(KeyCode.S) && !lockedState)
		{
			state = AIState.approaching;
		}

		if (!lockedState)
		{
			switch (state)
			{
				case AIState.approaching:
					nav.speed = 14f;
					anim.Play("Run");
					nav.destination = target.transform.position;
					break;
				case AIState.attacking:
					nav.speed = 0;
					anim.Play("CastSpell");
					lockedState = true;
					break;
				case AIState.fleeing:
					break;
				case AIState.idle:
					anim.Play("Idle");
					break;
			}
		}

		if (state == AIState.attacking)
		{
			if (attackCountdown <= 0)
			{
				lockedState = false;
				state = AIState.idle;
				attackCountdown = attackDelay;
				em.enabled = false;
			}
			else
			{
				attackCountdown -= Time.deltaTime;
				em.enabled = true;

				if(damageCountDown <= 0)
				{
					if (collCone.colliders.Count != 0)
					{
						foreach (Collider c in collCone.colliders)
						{
							if (c.GetComponent<Player>())
							{
								c.GetComponent<Player>().Damage(5);
							}
						}
					}

					damageCountDown = damageDelay;
				}
				else
				{
					damageCountDown -= Time.deltaTime;
				}
			}
		}

		bool canReachPlayer = false;
		if (collCone.colliders.Count != 0)
		{
			foreach (Collider c in collCone.colliders)
			{
				if (c.GetComponent<Player>())
				{
					canReachPlayer = true;
					break;
				}
			}
		}

		if (!lockedState && canReachPlayer)
			state = AIState.attacking;
	}
}
