using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickLevelButton : MonoBehaviour {

	public GameObject cv;
	public string levelInfo;

	public string sceneToLoad;
	public GameObject playButton;
	public Text levelText;
	public Text levelInfoText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		cv.GetComponent<Canvas> ().enabled = true;
		playButton.GetComponent<ChangeScene> ().destinationScene = sceneToLoad;
		levelText.text = "LEVEL " + sceneToLoad;
		levelInfoText.text = levelInfo;
	}
}
