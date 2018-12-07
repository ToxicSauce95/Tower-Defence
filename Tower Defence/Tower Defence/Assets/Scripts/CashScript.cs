using UnityEngine;
using UnityEngine.UI;

public class CashScript : MonoBehaviour {

	public Text CashText;
	public int Cash = 500;

	void Start ()
	{
		Cash = 500;
	}

	void Update ()
	{
	CashText.text = "Cash: " + Cash.ToString();
	}

}
