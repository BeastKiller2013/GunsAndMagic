using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTool : MonoBehaviour
{
	bool inUse = false;

	public GameObject template;

	int pillarCount = 0;

	Pillar[] pillars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0) && pillarCount < 2 && inUse)
		{
			RaycastHit[] rc = Physics.RaycastAll(transform.position, transform.Find("CameraBoom").Find("Main Camera").forward);

			foreach(RaycastHit r in rc)
			{
				if(r.normal == Vector3.up)
				{
					GameObject pillar1 = Instantiate(template, r.point+ new Vector3(0, 0, 0.1f), Quaternion.Euler(new Vector3(90, 0, 0)));
					pillar1.transform.localScale = new Vector3(100, 100, 1f);
					if(pillarCount == 1)
					{
						pillars[0].otherPillar = pillar1.GetComponent<Pillar>();
						pillar1.GetComponent<Pillar>().otherPillar = pillars[0];
						pillars[1].first = false;
					}
					else if (pillarCount == 0)
					{
						pillars[0] = pillar1.GetComponent<Pillar>();
						pillars[0].first = true;
					}

					pillarCount++;
				}
			}
		}
    }
}
