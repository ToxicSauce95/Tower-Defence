using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public Text HealthText;
	public int Health = 150;
	
	void Start ()
	{
		Health = 150;
		SetHealthText();
	}
	
	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			Health = Health - 1;
			SetHealthText();
		}

	}

	void SetHealthText()
	{
		HealthText.text = "Health: " + Health.ToString();
	}
}
