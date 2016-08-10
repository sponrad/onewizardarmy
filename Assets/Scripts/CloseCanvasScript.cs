using UnityEngine;
using System.Collections;

public class CloseCanvasScript : MonoBehaviour {

	public GameObject cv;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenCanvas(){
		cv.GetComponent<Canvas>().enabled = true;
	}

	public void CloseCanvas(){
		//cv.
		cv.GetComponent<Canvas>().enabled = false;
	}
}
