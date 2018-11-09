using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
	private Rigidbody rb;
	public float EnemySpeed = 0.0f;
	private Vector3 Forward;
	private float random;
	public int health = 10;
	private BasicBullet basicBullet;
	public GameObject otherGameobject;
	
	void Start()
	{
		GetComponent<Rigidbody>();
		health = 10;
	}
	
	private void Awake()
	{
		basicBullet = otherGameobject.GetComponent<BasicBullet>();
	}

	void Update()
	{
		transform.position += transform.forward * Time.deltaTime * EnemySpeed;
		
		if (health == 0)
		{
			Destroy(gameObject, 0);
		}
			
	}

	private void OnTriggerEnter(Collider col)
	{

		if(col.gameObject.CompareTag("Enemy"))
		{

		}
		
		else
		{

			if (col.gameObject.tag == "Random")
			{
				random = Random.value;
				if (random <= .5)
					transform.Rotate(new Vector3(0, 90, 0));
				if (random > .5)
					transform.Rotate(new Vector3(0, -90, 0));
			}

			if (col.gameObject.tag == "Right")
			{
				transform.Rotate(0, 90, 0);
			}

			if (col.gameObject.tag == "Left")
			{
				transform.Rotate(0, -90, 0);
			}

		if (col.gameObject.CompareTag("EndPoint"))
			{
				Destroy(gameObject, 0);
			}
		
		}

		if (col.gameObject.tag == "bullet")
		{
			health = health - basicBullet.damage;
		}

	}
	
}
