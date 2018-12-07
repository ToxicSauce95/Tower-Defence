using UnityEngine;

public class BasicTower : MonoBehaviour
{

	public GameObject bullet;
	public Transform SpawnPoint;
	private bool Shooting;
	public bool shoting;
	

	private void Start()
	{
		Shooting = false;
	}

	private void Update()
	{
		
		if (Shooting && !shoting)
		{
			SpawnEnemies(.5f);
			shoting = true;
		}

		if (!Shooting)
		{
			CancelInvoke("Repeat");
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Enemy"))
		{
			Shooting = true;
		}
	}
	

	

	void SpawnEnemies(float spawnRate)
	{
		InvokeRepeating("Repeat", .5f, spawnRate);
	}

	void Repeat()
	{
		Instantiate (bullet,SpawnPoint.position,SpawnPoint.rotation);
	}
}			