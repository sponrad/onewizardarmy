using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour {

	public GameObject towerSelectCanvas;
	public GameObject selectedTowerIndicator;

	public int towerNumber;
	public string towerName;

	private GameObject worldControl;
	private WorldScript worldScript;

	// Use this for initialization
	void Start () {
		worldControl = GameObject.Find ("WorldControl");
		worldScript = worldControl.GetComponent<WorldScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void showTowerSelectCanvas(){
		//only fired by towers in play, so towerNumber is set
		towerSelectCanvas.GetComponent<Canvas> ().enabled = true;
		float tempx = -150f + (towerNumber * 75f);
		selectedTowerIndicator.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tempx, 40f);

		worldScript.selectedTower = towerNumber;

		//TODO: also load info about tower to info (name and description), upgrade, and sell sections
	}

	public void swapTowers(){
		// only fired by clicking tower in inventory, so towerName is set
		//swap the globals
		string prevTower = Globals.towersInPlay[worldScript.selectedTower];
		Globals.towersInPlay [worldScript.selectedTower] = towerName;

		//TODO: remove towername from inventory, add prevtower to inventory
		Debug.Log("Swapping below into play.");
		Debug.Log(towerName);
		Globals.towerInventory.Remove(towerName);
		Debug.Log (prevTower);
		Globals.towerInventory.Add (prevTower);

		//redraw towers
		worldScript.updateTowers();
	}
}
