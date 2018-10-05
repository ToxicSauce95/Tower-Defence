using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{

	public Rigidbody Enemy;
	public float MovementSpeed = 10.0f;
	Vector3 lastEnemy = new Vector3();
	
	void Start ()
	{
		GetComponent<Rigidbody>();		 
	}
	
	
	void FixedUpdate()
	{
		transform.position += transform.forward * Time.deltaTime * MovementSpeed;
		
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Vector3 lft = transform.TransformDirection(Vector3.forward);
		
		if (Physics.Raycast(transform.position, fwd, 10))
		{
			if (Physics.Raycast(transform.position, lft, 10))
			{
				transform.Rotate(new Vector3(0,-90,0));	
			}
			else
			{
				transform.Rotate(new Vector3(0,180,0));
			}

		}
			
	}
}
