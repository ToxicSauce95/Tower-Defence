using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
	public Button StartButton;
	public Text RoundText;
	public int Round = 0;

	public GameObject Enemy;
	public Transform SpawnPoint;
	public int EnemyCount;
	public float SpawnRate;
	public float StartWait;
	public float WaveWait;
	public int i=0;
	
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
			StartCoroutine(SpawnWaves());
					
		}
	}

	IEnumerator SpawnWaves()
	{
		while (i < EnemyCount)
		{
			Instantiate(Enemy, SpawnPoint, SpawnPoint);
			i++;
			yield return new WaitForSeconds(SpawnRate);
			
		}
	StopCoroutine(SpawnWaves());	
		
	}


}



