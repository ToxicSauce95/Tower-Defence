using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform prefab;
	public int SpawnRate = 5;	
	
	void Start () {
		
	}
	
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.F))
		{
			Instantiate(prefab, new Vector3(SpawnRate * 2.0F, 0, 0), Quaternion.identity);
		}
		
	}
}
