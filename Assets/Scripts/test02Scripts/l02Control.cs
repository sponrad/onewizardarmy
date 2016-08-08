using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class l02Control : MonoBehaviour {

	public GameObject enemy;
	public Sprite[] enemySprites;
	public float updateTime;
	public bool gameRunning = true;

	private l02MonsterScript monsterScriptInstance;

	public List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		spawnEnemies ();
		spawnEnemyRow ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void moveEnemies(){
		foreach (GameObject enemy in enemyList) {
			enemy.GetComponent<l02MonsterScript> ().updateTick ();
		}
	}

	void spawnEnemies(){
		//assumes top row is empty as it is called AFTER moveEnemies or at the beginning of the level
		for (int j = 2; j > -1; j--) {
			for (int i = 0; i < 5; i++) {
				if (Random.value > 0.5) {
					float xpos = -2.44f + (i * 1.22f);
					float ypos = 6.09f - (1.04f * j);
					GameObject enemyInstance = (GameObject)Instantiate (enemy, new Vector3 (xpos, ypos, 0f), Quaternion.identity);
					enemyList.Add (enemyInstance);
				}
			}
		}
	}

	public void spawnEnemyRow(){
		moveEnemies ();

		//assumes top row is empty as it is called AFTER moveEnemies or at the beginning of the level
		for (int i = 0; i < 5; i++) {
			if (Random.value > 0.5) {
				float xpos = -2.44f + (i * 1.22f);
				GameObject enemyInstance = (GameObject)Instantiate (enemy, new Vector3 (xpos, 7.13f, 0f), Quaternion.identity);
				enemyList.Add (enemyInstance);
			}
		}
	}
}
