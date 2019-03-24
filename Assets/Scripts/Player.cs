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

	float yMin = 90;
	float yMax = -90;

	Rigidbody rb;

	float forceMult = 1000f;

	float jumpForce = 3000;

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
		if (yAngle + -lookSensitivity * Input.GetAxis("Mouse Y") > yMin)
		{
			yAngle = yMin;
		}
		else if (yAngle + -lookSensitivity * Input.GetAxis("Mouse Y") < yMax)
		{
			yAngle = yMax;
		}
		else
		{
			yAngle += -lookSensitivity * Input.GetAxis("Mouse Y");
		}

		transform.eulerAngles += lookSensitivity * new Vector3(0, Input.GetAxis("Mouse X"), 0);
		cameraBoom.localEulerAngles = new Vector3(yAngle, 0, 0);

		rb.AddForce(forceMult * (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")));

		if (rb.velocity.y < .1f && rb.velocity.y > -0.1f)
		{
			rb.AddForce(Input.GetAxis("Jump") * transform.forward * jumpForce);
		}
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
