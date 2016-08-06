using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string destinationScene;

	public void GoToScene(){
		Debug.Log ("GOTOSCENE");
		UnityEngine.SceneManagement.SceneManager.LoadScene (destinationScene, UnityEngine.SceneManagement.LoadSceneMode.Single);
		Time.timeScale = 1;
	}
}