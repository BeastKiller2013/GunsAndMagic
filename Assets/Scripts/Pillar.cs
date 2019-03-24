using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{

	public Pillar otherPillar;

	public bool first;

	bool wallUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.z > -100)
		{
			transform.localScale -= new Vector3(0, 0, 3);
		}

		if(otherPillar != null && first && !wallUp && Vector3.Distance(transform.position, otherPillar.transform.position) <= 10)
		{

		}
    }
}
