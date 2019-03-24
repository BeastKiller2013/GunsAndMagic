using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int health = 100;

	public Text healthText;

	Transform cameraBoom;

	float lookSensitivity = 2;

	float yAngle = 90;

	float yMin = -90;
	float yMax = 90;

	Rigidbody rb;

	float forceMult = 500f;

	// Start is called before the first frame update
	void Start()
    {
		healthText.text = "Health: " + health.ToString();
		cameraBoom = transform.Find("CameraBoom");
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		if (yAngle + -lookSensitivity * Input.GetAxis("Mouse Y") < yMin)
		{
			yAngle = yMin;
		}
		else if (yAngle + -lookSensitivity * Input.GetAxis("Mouse Y") > yMax)
		{
			yAngle = yMax;
		}
		else
		{
			yAngle += -lookSensitivity * Input.GetAxis("Mouse Y");
		}

		transform.eulerAngles += lookSensitivity * new Vector3(0, 0, Input.GetAxis("Mouse X"));
		cameraBoom.eulerAngles = new Vector3(yAngle, cameraBoom.eulerAngles.y, cameraBoom.eulerAngles.z);

		Debug.Log(Input.GetAxis("Horizontal"));
		Debug.Log(Input.GetAxis("Vertical"));
		Debug.Log(transform.up.ToString());

		rb.AddForce(forceMult * (-transform.up * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")));
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
