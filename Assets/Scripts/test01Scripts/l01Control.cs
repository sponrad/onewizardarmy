using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class l01Control : MonoBehaviour {

	public GameObject enemy;
	public float updateTime;
	public bool gameRunning = true;

	public List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		updateTick ();		
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
			enemy.GetComponent<l01MonsterScript> ().updateTick ();
		}
	}

	void spawnEnemies(){
		//assumes top row is empty as it is called AFTER moveEnemies or at the beginning of the level
		for (int i = 0; i < 5; i++) {
			float xpos = -2.6f + (i * 1.3f);
			GameObject enemyInstance = (GameObject) Instantiate (enemy, new Vector3 (xpos, 7.5f, 0f), Quaternion.identity);
			enemyInstance.GetComponent<l01MonsterScript> ().target = new Vector3 (xpos, 6f, 0f);
			enemyList.Add (enemyInstance);
		}
	}
}
