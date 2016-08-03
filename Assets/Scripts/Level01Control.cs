using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level01Control : MonoBehaviour {

	public GameObject enemy;
	public float updateTime;
	public bool gameRunning = true;

	public List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Invoke ("updateTick", 0f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void updateTick(){
		moveEnemies ();
		spawnEnemies ();

		if (gameRunning) {
			Invoke ("updateTick", updateTime);
		}
	}

	void moveEnemies(){
		foreach (GameObject enemy in enemyList) {
			enemy.GetComponent<MonsterScript> ().updateTick ();
		}
	}

	void spawnEnemies(){
		//assumes top row is empty as it is called AFTER moveEnemies or at the beginning of the level
		for (int i = 0; i < 5; i++) {
			float xpos = -3f + (i * 1.5f);
			GameObject enemyInstance = (GameObject) Instantiate (enemy, new Vector3 (xpos, 7.5f, 0f), Quaternion.identity);
			enemyInstance.GetComponent<MonsterScript> ().target = new Vector3 (xpos, 6f, 0f);
			enemyList.Add (enemyInstance);
		}
	}
}
