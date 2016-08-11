using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleControl : MonoBehaviour {

	public Text title;
	public Text play;

	private Outline titleOutline;
	private Outline playOutline;


	// Use this for initialization
	void Start () {
		titleOutline = title.GetComponent<Outline> ();
		playOutline = play.GetComponent<Outline> ();
	}
	
	// Update is called once per frame
	void Update () {
		float r = Mathf.Sin(Time.time);
		float g = Mathf.Cos(Time.time);
		float b = Mathf.Sin(Time.time + 3.14f);
				
		titleOutline.effectColor = new Color (r, g, b, 1f);

		playOutline.effectColor = new Color (r, g, b, 1f);
	}


}
