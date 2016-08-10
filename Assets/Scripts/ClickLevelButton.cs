using UnityEngine;
using System.Collections;

public class ClickLevelButton : MonoBehaviour {

	public GameObject cv;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		cv.GetComponent<Canvas> ().enabled = true;
	}
}
