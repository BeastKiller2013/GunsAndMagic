using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int health = 100;

	public Text healthText;

	// Start is called before the first frame update
	void Start()
    {
		healthText.text = "Health: " + health.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Damage(int amount)
	{
		if(health - amount < 0)
		{
			health = 0;
		}
		else
		{
			health -= amount;
		}

		healthText.text = "Health: " + health.ToString();
	}
}
