using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public Text HealthText;
	private int Health = 150;
	
	void Start () 
	{
		Health = 150;
	}
	
	void Update () 
	{
		HealthText.text = "Health: " + Health.ToString();
	}

	private void OnCollisionEnter(Collision other)
	{
		Health = Health - 10;
	}
}
