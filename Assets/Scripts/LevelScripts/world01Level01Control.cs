using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class world01Level01Control : MonoBehaviour {

	private l02MonsterScript monsterScriptInstance;

	public GameObject enemy;
	public GameObject healthPrefab;
	public GameObject columnAimerObject;
	public GameObject bulwark;

	private Canvas columnAimerCanvas;

	public int health = 10;
	public int spawnEnemyCount;
	public int bulwarkRows;

	private GameObject selectedTower;
	private int selectedColumn;

	// Use this for initialization
	void Start () {
		StartCoroutine ("spawnEnemies");
		placeBulwarks ();
		placeTowers ();
		placePowerUps ();
		drawHealth ();

		columnAimerCanvas = columnAimerObject.GetComponent<Canvas> ();
		columnAimerCanvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("s")){
			spawnEnemyRow();
		}
	}

	void moveEnemies(){
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy")) {
			enemy.BroadcastMessage("updateTick");
		}
	}

	IEnumerator spawnEnemies(){
		for (int i = 0; i < spawnEnemyCount; i++) {
			spawnEnemyRow();
			yield return new WaitForSeconds (0.1f);
		}
	}

	public void spawnEnemyRow(){
		for (int i = 0; i < 5; i++) {
			if (Random.value > -1) {
				float xpos = Globals.gridStartX + (i * Globals.gridXSpacing);

				/*if (Globals.grid[i, Globals.rows-1] != null) {
					Globals.grid [i, Globals.rows-1].BroadcastMessage ("Push"); //TODO: race condition created here
				}*/

				//spawn into 8th row and then push down to visible 7th row
				Globals.grid[i, Globals.rows-1] = Instantiate (enemy, new Vector3 (xpos, Globals.gridSpawnY, 0f), Quaternion.identity) as GameObject;
				Globals.grid[i, Globals.rows-1].BroadcastMessage("SetGridPosition", new int[] {i, Globals.rows-1});
				Globals.grid[i, Globals.rows-1].BroadcastMessage("Push");
			}
		}
	}

	public void towerFired(){
		//check to see if all active towers are on cooldown...
		bool cooldown = true;
		foreach (GameObject tower in GameObject.FindGameObjectsWithTag ("tower")) {
			if (tower.GetComponent<GambleTowerScript> ().coolingDown == 0) {
				cooldown = false;
			}
		}

		//if cooldown is still true (all towers are cooling down) move enemies down (freeze input temporarily)
		if (cooldown == true) {
			moveEnemies ();
			moveEnemies ();
			moveEnemies ();
			moveEnemies ();
			spawnEnemies ();

			foreach (GameObject tower in GameObject.FindGameObjectsWithTag ("tower")) {
				tower.BroadcastMessage ("tick");
			}
		}
	}

	public void placeBulwarks(){
		for (int j = 0; j < bulwarkRows; j++) {
			for (int i = 0; i < Globals.columns; i++){
				Vector3 bulwarkLoc = new Vector3 (Globals.gridStartX + (i * Globals.gridXSpacing), Globals.gridYSpacing * j, 0);
				Globals.grid[i,j] = Instantiate( bulwark, bulwarkLoc, Quaternion.identity) as GameObject;
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

	public void placePowerUps(){
		Vector3 consumableLoc = new Vector3 (Globals.equippedConsumablePosition [0], Globals.equippedConsumablePosition [1], 0f);
		Instantiate (Resources.Load ("Items/" + Globals.equippedConsumable), consumableLoc, Quaternion.identity);
	}

	public void enemyHitTower(GameObject enemy){
		health -= 1;
		if (health == 0) {
			//gameover
			UnityEngine.SceneManagement.SceneManager.LoadScene ("title", UnityEngine.SceneManagement.LoadSceneMode.Single);
			Time.timeScale = 1;
		}

		Destroy (enemy);
		drawHealth ();
	}

	public void drawHealth(){
		foreach (GameObject health in GameObject.FindGameObjectsWithTag ("heart")) {
			Destroy (health);
		}

		for (int i = 0; i < health; i++) {
			float xpos = (i - 5) * 0.5f;
			Instantiate (healthPrefab, new Vector3 (xpos, -4.5f, 0f), Quaternion.identity);
		}

	}

	public void showColumnAimer(GameObject selectedTowerObject){
		columnAimerCanvas.enabled = true;
		selectedTower = selectedTowerObject;
	}

	public void chooseColumn(int selectedColumn){
		Debug.Log (selectedColumn);
		selectedTower.BroadcastMessage ("SetTargetAndFire", selectedColumn);
		hideColumnAimer ();
	}

	public void hideColumnAimer(){
		columnAimerCanvas.enabled = false;
	}
}
