using UnityEngine;
using System.Collections;

public class TowerButton : MonoBehaviour {

	public GameObject towerSelectCanvas;
	public int towerNumber;
	public GameObject selectedTowerIndicator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void showTowerSelectCanvas(){
		towerSelectCanvas.GetComponent<Canvas> ().enabled = true;
		float tempx = -150f + (towerNumber * 75f);
		selectedTowerIndicator.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (tempx, 40f); ;
	}
}
