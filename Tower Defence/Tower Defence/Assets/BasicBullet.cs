using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{

	
	private float speed = 60f;
	
	public int damage = 10;
	
	
	void Update ()
	{
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	private void OnTriggerEnter(Collider col)
	{
			Destroy(gameObject, 0);
	}
}
