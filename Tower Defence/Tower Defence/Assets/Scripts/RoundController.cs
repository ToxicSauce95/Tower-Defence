using UnityEngine;
using UnityEngine.UI;


public class RoundController : MonoBehaviour
{
	public Button StartButton;
	public Transform button;
	public Text RoundText;
	private int Round;
	
	public int MaxEnemy = 0; 
	public int EnemyCount = 0;
	
	public GameObject Enemy;
	public Transform SpawnPoint;
	
	private EnemyCounter enemyCounter;
	public GameObject EnemyCounter;
	private int SpawedEnemies;
	
	private bool _RoundStart = false;
	private bool EnemiesSpawned = false;
	

	void Start()
	{
		SpawedEnemies = 0;
		Button btn1 = StartButton.GetComponent<Button>();
		Round = 0;
		btn1.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Round += 1;
        RoundText.text = "Round: " + Round.ToString();
        
		_RoundStart = true;
        EnemyCount += 5;
        EnemiesSpawned = false;
	}

	void Update()
	{

		SpawedEnemies = enemyCounter.SpawnedEnemies;
		
		if (MaxEnemy >= EnemyCount)
        			CancelInvoke();
		if (!EnemiesSpawned && _RoundStart)
		{
			SpawnEnemies(.5f);
			EnemiesSpawned = true;	
		}
		
		if (SpawedEnemies > 1)
		{
			StartButton.GetComponent<Button>().interactable = false;
		}	
		if (SpawedEnemies < 1)
		{
			StartButton.GetComponent<Button>().interactable = true;
        }
		
	}

	void SpawnEnemies(float spawnRate)
	{ 		
		InvokeRepeating("Repeat", 0f, spawnRate);
		MaxEnemy = 0;
	}
	
	void Repeat()
	{	
		MaxEnemy++;
		Instantiate (Enemy,SpawnPoint.position,SpawnPoint.rotation);
	}
	
	private void Awake()
	{
		enemyCounter = EnemyCounter.GetComponent<EnemyCounter>();
	}

}



