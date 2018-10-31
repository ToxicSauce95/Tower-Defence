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
		if(col.gameObject.CompareTag("Enemy"))
		{
			Health++;
			SetHealthText();
			
		}

	}

	void SetHealthText()
	{
		HealthText.text = "Health: " + Health.ToString();
	}
}
