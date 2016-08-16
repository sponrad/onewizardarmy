using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WorldScript : MonoBehaviour {
	
	public Canvas levelSelectedCanvas;
	public Canvas towerSelectedCanvas;

	public GameObject tower1Button;
	public GameObject tower2Button;
	public GameObject tower3Button;
	public GameObject tower4Button;
	public GameObject tower5Button;

	public GameObject towerCustomize1Button;
	public GameObject towerCustomize2Button;
	public GameObject towerCustomize3Button;
	public GameObject towerCustomize4Button;
	public GameObject towerCustomize5Button;

	public Text goldText;

	private GameObject[] ownedTowers = new GameObject[5];


	// Use this for initialization
	void Start () {
		//get the owned towers into a gameobject
		for (int i = 0; i < 5; i++) {
			Debug.Log (Globals.towersInPlay [i]);
			ownedTowers [i] = Resources.Load ("Towers/" + Globals.towersInPlay[i]) as GameObject;
		}

		updateTowerImages ();

		goldText.text = Globals.gold.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void updateTowerImages(){
		//place the tower sprites on the canvas object
		tower1Button.GetComponent<Image>().sprite = ownedTowers[0].GetComponent<SpriteRenderer>().sprite;
		tower2Button.GetComponent<Image>().sprite = ownedTowers[1].GetComponent<SpriteRenderer>().sprite;
		tower3Button.GetComponent<Image>().sprite = ownedTowers[2].GetComponent<SpriteRenderer>().sprite;
		tower4Button.GetComponent<Image>().sprite = ownedTowers[3].GetComponent<SpriteRenderer>().sprite;
		tower5Button.GetComponent<Image>().sprite = ownedTowers[4].GetComponent<SpriteRenderer>().sprite;

		towerCustomize1Button.GetComponent<Image>().sprite = ownedTowers[0].GetComponent<SpriteRenderer>().sprite;
		towerCustomize2Button.GetComponent<Image>().sprite = ownedTowers[1].GetComponent<SpriteRenderer>().sprite;
		towerCustomize3Button.GetComponent<Image>().sprite = ownedTowers[2].GetComponent<SpriteRenderer>().sprite;
		towerCustomize4Button.GetComponent<Image>().sprite = ownedTowers[3].GetComponent<SpriteRenderer>().sprite;
		towerCustomize5Button.GetComponent<Image>().sprite = ownedTowers[4].GetComponent<SpriteRenderer>().sprite;

	}
}
