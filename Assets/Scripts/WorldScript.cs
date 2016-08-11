using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldScript : MonoBehaviour {

	public GameObject[] ownedTowers = new GameObject[5];
	public Canvas levelSelectedCanvas;

	public GameObject tower1Button;
	public GameObject tower2Button;
	public GameObject tower3Button;
	public GameObject tower4Button;
	public GameObject tower5Button;


	// Use this for initialization
	void Start () {
		//get the owned towers into a gameobject
		for (int i = 0; i < 5; i++) {
			Debug.Log (Globals.towersInPlay [i]);
			ownedTowers [i] = Resources.Load ("Towers/" + Globals.towersInPlay[i]) as GameObject;
		}

		//place the tower sprites on the canvas object
		tower1Button.GetComponent<Image>().sprite = ownedTowers[0].GetComponent<SpriteRenderer>().sprite;
		tower2Button.GetComponent<Image>().sprite = ownedTowers[1].GetComponent<SpriteRenderer>().sprite;
		tower3Button.GetComponent<Image>().sprite = ownedTowers[2].GetComponent<SpriteRenderer>().sprite;
		tower4Button.GetComponent<Image>().sprite = ownedTowers[3].GetComponent<SpriteRenderer>().sprite;
		tower5Button.GetComponent<Image>().sprite = ownedTowers[4].GetComponent<SpriteRenderer>().sprite;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
