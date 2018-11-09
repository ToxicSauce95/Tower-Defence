﻿using UnityEngine;
using UnityEngine.UI;


public class RoundController : MonoBehaviour
{
	public Button StartButton;
	public Text RoundText;
	private int Round;
	public Text EnemyCounter;
	[SerializeField] public int enemy;
	
	private int SpawnedEnemies = 0;
	private static int EnemyCount = 0;
	public GameObject Enemy;
	public Transform SpawnPoint;


	
	private bool _RoundStart = false;
	private bool EnemiesSpawned = false;

	void Start()
	{
		Button btn1 = StartButton.GetComponent<Button>();
		Round = 0;
		btn1.onClick.AddListener(TaskOnClick);
		EnemyCounter.text = "Enemies: " + enemy.ToString();
		enemy = 0;
	}

	void TaskOnClick()
	{
		RoundShit();
	}

	void RoundShit()
	{
		Round += 1;
		RoundText.text = "Round: " + Round.ToString();
		
        _RoundStart = true;
        EnemyCount += 5;
		EnemiesSpawned = false;
		
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
		EnemyCounter.text = "Enemies: " + enemy.ToString();
		
		
	}

	void SpawnEnemies(float spawnRate)
	{ 		
		InvokeRepeating("Repeat", .5f, spawnRate);
		SpawnedEnemies = 0;
	}
	
	void Repeat()
	{	
		SpawnedEnemies++;
		enemy++;
		Instantiate (Enemy,SpawnPoint.position,SpawnPoint.rotation);
	}

}



