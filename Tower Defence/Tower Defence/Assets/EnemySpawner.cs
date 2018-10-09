using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

	public GameObject Enemy;
	public int SpawnRate = 5;
	public Transform Spawnpoint;
	private int Wave = 0;
	public Button StartButton;
	
	void Start()
	{
		Button btn1 = StartButton.GetComponent<Button>();


		//Calls the TaskOnClick/TaskWithParameters method when you click the Button
		btn1.onClick.AddListener(TaskOnClick);
	}



	void TaskOnClick()
	{
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
	}

	void TaskWithParameters(string message)
	{
		//Output this to console when the Button is clicked
		Debug.Log(message);
	}
}
