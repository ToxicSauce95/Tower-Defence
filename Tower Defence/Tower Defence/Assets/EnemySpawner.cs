using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using Object = UnityEngine.Object;

public class EnemySpawner : MonoBehaviour
{
	public GameObject Enemy;
	public Transform SpawnPoint;
	public Button StartButton;
	public Text RoundText;
	public int Round = 0;
	public int SpawnRate = 5;
	private int EnemyAmount = 0;
	
	
	void Start()
	{
		Button btn1 = StartButton.GetComponent<Button>();
		Round = 0;
		
		SetRoundText ();
		
		btn1.onClick.AddListener(TaskOnClick);
	}

	
	void TaskOnClick()
	{
		Round = Round + 1;
		SetRoundText();
		
		Debug.Log("You have clicked the button!");
	}
		
	void SetRoundText()
	{
		RoundText.text = "Round: " + Round.ToString();
	}

	void Update()
	{
		if (Round == 1)
		{
			EnemyAmount = 10;
			Invoke("Spawn", 1);
		}
	}


	void Spawn()
	{
		for (var i = 0; i < EnemyAmount; i++)
			new WaitForSeconds(SpawnRate);
			
		Instantiate(Enemy, SpawnPoint);

	}

}


