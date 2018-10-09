using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{

	public float MovementSpeed = 10.0f;
	private float random;

	void Start()
	{
		GetComponent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other)
	{
		
		
		
		if (other.gameObject.CompareTag("Enemy"))
		{
		
		}
		else
		{
		

			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			Vector3 left = transform.TransformDirection(Vector3.left);
			Vector3 right = transform.TransformDirection(Vector3.right);

			if (Physics.Raycast(transform.position, fwd, 5))
			{
				if (Physics.Raycast(transform.position, left, 5))
				{
					transform.Rotate(new Vector3(0, 90, 0));
				}
				else if (Physics.Raycast(transform.position, right, 5))
				{
					transform.Rotate(new Vector3(0, -90, 0));
				}
				else
				{
					random = Random.value;
					if (random <= .5)
						transform.Rotate(new Vector3(0, 90, 0));
					if (random > .5)
						transform.Rotate(new Vector3(0, -90, 0));

				}
			}
		}
	}

	private void Update()
	{
		transform.position += transform.forward * Time.deltaTime * MovementSpeed;
		
	}
}
