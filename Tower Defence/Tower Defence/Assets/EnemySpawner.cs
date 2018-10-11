using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class EnemySpawner : MonoBehaviour
{

	public GameObject Enemy;
	public Transform Spawnpoint;
	public Button StartButton;
	public Text RoundText;
	public int SpawnRate = 5;
	public int Round = 0;
	
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



	void TaskWithParameters(string message)
	{
		//Output this to console when the Button is clicked
		Debug.Log(message);
	}
}
