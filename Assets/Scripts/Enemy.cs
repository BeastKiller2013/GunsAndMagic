using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	int health = 100;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void damage(int dam)
	{
		if (health - dam < 0)
		{
			health = 0;
			death();
		}
		else
			health -= dam;
	}

	protected virtual void death()
	{

	}
}
