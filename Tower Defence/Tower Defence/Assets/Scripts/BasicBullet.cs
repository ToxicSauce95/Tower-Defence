using UnityEngine;

public class BasicBullet : MonoBehaviour
{

	
	private float speed = 60f;
	
	public float damage = 10f;
	
	
	
	void Update ()
	{
		transform.position += transform.forward * Time.deltaTime * speed;
		Destroy(gameObject, 2);
	}

	private void OnTriggerEnter(Collider col)
	{
			Destroy(gameObject, 0);
	}
	
}
		

