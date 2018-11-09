using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashScript : MonoBehaviour {

	[SerializeField] private Text CashText;
	private int Cash = 500;
	public Text HealthText;
	private int Health = 150;
	private RoundController roundController;
	public GameObject otherGameobject;
	
	void Start ()
	{
		Health = 150;
		SetHealthText();
		Cash = 500;

		
	}


	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Enemy"))
		{
			Health--;
			SetHealthText();
			Cash += 10;
			roundController.enemy--;
		}



	}

	private void Awake()
	{
		roundController = otherGameobject.GetComponent<RoundController>();
	}

	void SetHealthText()
	{
		HealthText.text = "Health: " + Health.ToString();
	}

	void Update () {
		
		CashText.text = "Cash: " + Cash.ToString();
		
	}
}
