using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    
	private Rigidbody rb;
	public float EnemySpeed = 0.0f;
	private Vector3 Forward;
	private float random;
	
	public float health = 10f;

	public int cash;
	private BasicBullet basicBullet;
    public GameObject bullet;

	void Start()
	{
		GetComponent<Rigidbody>();
		health = 10f;
	}
	
	private void Awake()
	{
		basicBullet = bullet.GetComponent<BasicBullet>();
	}

	void Update()
	{
		transform.position += transform.forward * Time.deltaTime * EnemySpeed;
		
		if (health <= 0f)
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

	
