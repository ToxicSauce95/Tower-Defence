using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
	public int SpawnedEnemies;
	public Text EnemyCounterText;
	
	void Start ()
	{
		SpawnedEnemies = 0;
	}
	
	void Update ()
	{

		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			SpawnedEnemies = enemies.Length;

		SetSpaenedEnemiesText();
	}

     void SetSpaenedEnemiesText()
     {
	     EnemyCounterText.text = "Enemies: " + SpawnedEnemies.ToString();
     }
}
