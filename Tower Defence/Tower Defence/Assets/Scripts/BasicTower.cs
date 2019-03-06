using UnityEngine;

public class BasicTower : MonoBehaviour
{

	public GameObject bullet;
	//public Transform SpawnPoint;
	private bool Shooting;
	//public bool shoting;
    public int EnemiesOnScreen = 0;
    public float RPM = 60;
    public float TimeBetweenShots;
    public float TimeSinceLastShot;


    private void Start()
	{
		Shooting = false;
        TimeBetweenShots = RPM/60;
	}

	void Update()
	{
        TimeSinceLastShot += Time.deltaTime;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesOnScreen = enemies.Length;

		/*if (Shooting && !shoting)
		{
			SpawnEnemies(1f);
			shoting = true;
		}

		if (!Shooting)
		{
			CancelInvoke("Repeat");
		}*/
        if(Shooting == true && TimeSinceLastShot >= TimeBetweenShots)
        {
            Shot();
        }

	}

	void OnTriggerStay(Collider col)
	{
        if (EnemiesOnScreen >= 1)
        {
            Shooting = true;
        }
        
        if (EnemiesOnScreen <= 0)
        {
            Shooting = false;
            
        }
    }
	

	

	/*void SpawnEnemies(float spawnRate)
	{
		InvokeRepeating("Shot", .5f, spawnRate);
	}*/

	void Shot()
	{
        Debug.Log("Boom");
        TimeSinceLastShot = 0;
        Instantiate(bullet);
	}
}			