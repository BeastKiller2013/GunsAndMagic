using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		state = AIState.approaching;
		fireAttackPart = transform.Find("FireBall").GetComponent<ParticleSystem>();
		em = fireAttackPart.emission;
		em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

		if(Input.GetKey(KeyCode.A))
		{
			state = AIState.attacking;
		}
		else
		{
			state = AIState.approaching;
		}

        switch(state)
		{
			case AIState.approaching:
				anim.Play("Run");
				break;
			case AIState.attacking:
				lockedState = true;
				anim.Play("CastSpell");
				break;
			case AIState.fleeing:
				break;
			case AIState.idle:
				break;
		}
    }
}
