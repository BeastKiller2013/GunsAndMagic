using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	bool inUse = true;

	public AudioSource AS;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0) && inUse)
		{
			AS.Play();
			RaycastHit[] rc = Physics.RaycastAll(transform.position, transform.Find("CameraBoom").Find("Main Camera").forward, 11);

			if(rc[0].collider.GetComponent<Enemy>())
			{
				rc[0].collider.GetComponent<Enemy>().damage(90);
			}
			
		}
	}
}
