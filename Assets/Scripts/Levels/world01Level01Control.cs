using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class world01Level01Control : MonoBehaviour {

	private l02MonsterScript monsterScriptInstance;

	public GameObject enemy;
	public Text healthText;

	public int health = 10;

	// Use this for initialization
	void Start () {
		spawnEnemies ();
		spawnEnemyRow ();
		placeTowers ();
	}

	// Update is called once per frame
	void Update () {
		healthText.text = string.Empty.PadLeft(health, '❤');
	}

	void moveEnemies(){
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy")) {
			enemy.BroadcastMessage("updateTick");
		}
	}

	void spawnEnemies(){
		//assumes top row is empty as it is called AFTER moveEnemies or at the beginning of the level
		for (int j = 2; j > -1; j--) {
			for (int i = 0; i < 5; i++) {
				if (Random.value > 0.5) {
					float xpos = Globals.gridStartX + (i * Globals.gridXSpacing);
					float ypos = Globals.gridStartY - (Globals.gridYSpacing * j);
					Instantiate (enemy, new Vector3 (xpos, ypos, 0f), Quaternion.identity);
				}
			}
		}
	}

	public void spawnEnemyRow(){
		moveEnemies ();

		//assumes top row is empty as it is called AFTER moveEnemies or at the beginning of the level
		for (int i = 0; i < 5; i++) {
			if (Random.value > 0.5) {
				float xpos = Globals.gridStartX + (i * Globals.gridXSpacing);
				Instantiate (enemy, new Vector3 (xpos, Globals.gridSpawnY, 0f), Quaternion.identity);
			}
		}
	}

	public void placeTowers(){
		for (int i = 0; i < 5; i++) {
			Debug.Log (Globals.towersInPlay [i]);
			Vector3 towerLoc = new Vector3 ( Globals.towerPositions[i][0], Globals.towerPositions[i][1], 0f);
			Instantiate( Resources.Load ("Towers/" + Globals.towersInPlay[i]) , towerLoc, Quaternion.identity);
		}
	}

	public void enemyHitTower(GameObject enemy){
		health -= 1;
		if (health == 0) {
			//gameover
			UnityEngine.SceneManagement.SceneManager.LoadScene ("title", UnityEngine.SceneManagement.LoadSceneMode.Single);
			Time.timeScale = 1;
		}

		Destroy (enemy);
	}
}
