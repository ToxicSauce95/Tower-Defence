﻿using UnityEditor;
 using UnityEngine;
using UnityEngine.UI;
 using System.Collections;


public class RoundController : MonoBehaviour
{
	public Button StartButton;
	public Transform button;
	public Text RoundText;
	private int Round;
	public Text EnemyCounter;
	public float enemy = 0;
	
	public int SpawnedEnemies = 0;
	public int EnemyCount = 0;
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
		
		if (enemy >= 1)
		{
			if (StartButton.GetComponent<Button>().IsInteractable() == true)
			{
				StartButton.GetComponent<Button>().interactable = false;
			}
		}
		if (enemy <= 1)
		{
			if (StartButton.GetComponent<Button>().IsInteractable() == false)
			{
				StartButton.GetComponent<Button>().interactable = true;
			}
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
		enemy++;
		Instantiate (Enemy,SpawnPoint.position,SpawnPoint.rotation);
	}

}



