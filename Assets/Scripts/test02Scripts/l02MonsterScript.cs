using UnityEngine;
using System.Collections;

public class l02MonsterScript : MonoBehaviour {

	public float speed = 4.0f;
	public Vector3 target;
	public string[] types;
	public string type;
	public Sprite[] typeSprites;

	private SpriteRenderer sr;
	private int stunDuration;

	// Use this for initialization
	void Start () {
		target = transform.position;
		int tempInt = Random.Range (0, types.Length);
		type = types[tempInt];
		sr = GetComponent<SpriteRenderer> ();
		sr.sprite = typeSprites [tempInt];

		if (sr.bounds.extents.x > 0.5f){
			transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target, step);
	}

	public void updateTick(){
		target = new Vector3 (target.x, target.y - 1.04f, target.z);

		if (stunDuration > 0) {
			target = transform.position;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
			stunDuration -= 1;
			if (stunDuration <= 0) {
				gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
	}

	public void OnDestroy(){
		//GameObject.Find ("Control").GetComponent<l02Control> ().enemyList.Remove (gameObject);
	}

	void stunned(int stunTime){
		Debug.Log ("stun called");
		// add the stunTime this monsters stunduration
		stunDuration += stunTime;
	}
}
