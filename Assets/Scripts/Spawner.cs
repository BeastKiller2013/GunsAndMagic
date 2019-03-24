using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject spawnItem;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void doSpawn(GameObject pawn)
	{
		GameObject newSpawn = Instantiate(pawn, transform.position + new Vector3(0, 0, 3), Quaternion.Euler(0, transform.eulerAngles.y, 0));
		newSpawn.GetComponent<Skeleton>().enabled = true;
		newSpawn.GetComponent<Rigidbody>().useGravity = true;
	}

	public void doSpawn()
	{
		GameObject newSpawn = Instantiate(spawnItem, transform.position + new Vector3(0, 0, 3), Quaternion.Euler(0, transform.eulerAngles.y, 0));
		newSpawn.GetComponent<Skeleton>().enabled = true;
	}
}
