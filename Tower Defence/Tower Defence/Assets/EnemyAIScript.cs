using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
	private Rigidbody rb;
	public float EnemySpeed = 0.0f;
	private Vector3 Forward;
	private float random;
	void Start()
	{
		GetComponent<Rigidbody>();
		
	}

	void Update()
	{
		transform.position += transform.forward * Time.deltaTime * EnemySpeed;
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
		
	}
	
}
