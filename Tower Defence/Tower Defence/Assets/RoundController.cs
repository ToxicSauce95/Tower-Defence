using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
	public Button StartButton;
	public Text RoundText;
	public int Round;

	public GameObject Enemy;
	public Transform SpawnPoint;
	public int EnemyCount;
	public int i;
	
	void Start()
	{
		Button btn1 = StartButton.GetComponent<Button>();
		Round = 0;
		
		SetRoundText();

		btn1.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Round = Round + 1;
		EnemyCount = EnemyCount + 10;
		SetRoundText();
			
		Debug.Log("You have clicked the button!");
	}

	void SetRoundText()
	{
		RoundText.text = "Round: " + Round.ToString();
	}

	private void Update()
	{
		
		if (Round == 1)
		{
			
			while (GameObject.FindGameObjectsWithTag("Enemy").Length < EnemyCount)
			{
				InvokeRepeating("Repeat", 0f, 5f);
			}
			if (GameObject.FindGameObjectsWithTag("Enemy").Length > EnemyCount)
			{
				CancelInvoke();
			}
				
		}
	}

	private void Repeat()
	{
		Instantiate(Enemy, SpawnPoint, SpawnPoint);	
	}

}



