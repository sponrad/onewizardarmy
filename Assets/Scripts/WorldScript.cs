using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


public class WorldScript : MonoBehaviour {
	
	public Canvas levelSelectedCanvas;
	public GameObject towerSelectScrollviewContent;

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

	private GameObject[] towersInPlay = new GameObject[5];


	// Use this for initialization
	void Start () {
		//get the owned towers into a gameobject
		for (int i = 0; i < 5; i++) {
			Debug.Log (Globals.towersInPlay [i]);
			towersInPlay [i] = Resources.Load ("Towers/" + Globals.towersInPlay[i]) as GameObject;
		}

		updateTowers ();

		goldText.text = Globals.gold.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
	}

	void updateTowers(){
		//place the tower sprites on the canvas object
		tower1Button.GetComponent<Image>().sprite = towersInPlay[0].GetComponent<SpriteRenderer>().sprite;
		tower2Button.GetComponent<Image>().sprite = towersInPlay[1].GetComponent<SpriteRenderer>().sprite;
		tower3Button.GetComponent<Image>().sprite = towersInPlay[2].GetComponent<SpriteRenderer>().sprite;
		tower4Button.GetComponent<Image>().sprite = towersInPlay[3].GetComponent<SpriteRenderer>().sprite;
		tower5Button.GetComponent<Image>().sprite = towersInPlay[4].GetComponent<SpriteRenderer>().sprite;

		towerCustomize1Button.GetComponent<Image>().sprite = towersInPlay[0].GetComponent<SpriteRenderer>().sprite;
		towerCustomize2Button.GetComponent<Image>().sprite = towersInPlay[1].GetComponent<SpriteRenderer>().sprite;
		towerCustomize3Button.GetComponent<Image>().sprite = towersInPlay[2].GetComponent<SpriteRenderer>().sprite;
		towerCustomize4Button.GetComponent<Image>().sprite = towersInPlay[3].GetComponent<SpriteRenderer>().sprite;
		towerCustomize5Button.GetComponent<Image>().sprite = towersInPlay[4].GetComponent<SpriteRenderer>().sprite;

		//remove all children in the scrollview content
		foreach (Transform child in towerSelectScrollviewContent.transform) {
			Destroy (child.gameObject);
		}
			
		//instantiate a scrollviewtower in the scrollviewcontent area
		//towerSelectScrollviewContent
		for (int i = 0; i < Globals.towerInventory.Count (); i++) {
			Debug.Log (Globals.towerInventory[i]);
			float tempx = (i * 70f)+50f;
			float tempy = (Mathf.FloorToInt(i/4)+1) * -60;
			GameObject scrollviewItem = Instantiate (Resources.Load ("ScrollViewTower"), new Vector3 (tempx, tempy), Quaternion.identity) as GameObject;
			scrollviewItem.transform.SetParent (towerSelectScrollviewContent.transform, false);

			GameObject tempTower = Resources.Load ("Towers/" + Globals.towerInventory [i]) as GameObject;

			scrollviewItem.GetComponent<Image> ().sprite = tempTower.GetComponent<SpriteRenderer> ().sprite;
		}

	}
}
