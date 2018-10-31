using UnityEngine;
using UnityEngine.UI;


public class RoundController : MonoBehaviour
{
	[SerializeField] private Button StartButton;
	[SerializeField] private Text RoundText;
	private int Round;
	[SerializeField] private Text EnemyCounter;
	public static int _Enemy;
	[SerializeField] private Text CashText;
	private int Cash = 500;
	
	private int SpawnedEnemies = 0;
	private static int EnemyCount = 0;
	[SerializeField] private GameObject Enemy;
	public Transform SpawnPoint;


	
	private bool _RoundStart = false;
	private bool EnemiesSpawned = false;

	void Start()
	{
		Button btn1 = StartButton.GetComponent<Button>();
		Round = 0;
		btn1.onClick.AddListener(TaskOnClick);
		
	}

	void TaskOnClick()
	{
		RoundShit();
	}

	void RoundShit()
	{
		Round += 1;
		RoundText.text = "Round: " + Round.ToString();
		Cash += 100;
        _RoundStart = true;
        EnemyCount += 5;
		EnemiesSpawned = false;
		EnemyCounter.text = "Enemies: " + _Enemy.ToString();
        CashText.text = "Cash: " + Cash.ToString();
	}

	void Update()
	{
		if (SpawnedEnemies >= EnemyCount)
        			CancelInvoke();
		if (!EnemiesSpawned && _RoundStart)
		{
			SpawnEnemies(.5f);
			EnemiesSpawned = true;	
		}
		
	}

	void SpawnEnemies(float spawnRate)
	{ 		
		InvokeRepeating("Repeat", .5f, spawnRate);
		SpawnedEnemies = 0;
	}
	
	void Repeat()
	{	
		SpawnedEnemies++;
		_Enemy++;
		Instantiate (Enemy,SpawnPoint.position,SpawnPoint.rotation);
	}

}



