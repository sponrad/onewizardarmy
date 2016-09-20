using UnityEngine;
using System.Collections;

public class l02MonsterScript : MonoBehaviour {

	public float speed = 4.0f;
	public Vector3 target;
	public string[] types;
	public string type;
	public Sprite[] typeSprites;
	public int[] gridPosition;

	private SpriteRenderer sr;
	private int stunDuration = 0;

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

		Fall ();
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target, step);
	}

	public void Fall(){
		//find the farthest down location that is not occupied and set target to it
		//Vector3 tempTarget = target;
	}

	public void Push(){
		Debug.Log ("PUSH CALLED");
		//set target to position below so object moves on down
		Debug.Log(transform.position.y);
		target = new Vector3 (transform.position.x, transform.position.y - Globals.gridYSpacing, transform.position.z);
		Debug.Log (transform.position.y - Globals.gridYSpacing);
		Debug.Log (target);

		if (gridPosition [1] != 0) {
			Debug.Log (gridPosition [1]);
			gridPosition [1] -= 1;
			Debug.Log (gridPosition [1]);

			//check for what is at position below
			if (Globals.grid[gridPosition[0], gridPosition[1]] != null){
				string objectBelowTag = Globals.grid[gridPosition[0], gridPosition[1]].tag;

				//if it is a bulwark destroy the bulwark
				if (objectBelowTag == "bulwark") {
					Destroy ( Globals.grid [gridPosition [0], gridPosition [1]] );
				}

				//if it is an enemy trigger push on that enemy
				if (objectBelowTag == "enemy") {
					Debug.Log ("ENEMY ON ENEMY");
					Globals.grid [gridPosition [0], gridPosition [1]].BroadcastMessage ("Push");
				}
			}
			//update grid for this item, previous entry should be taken care of by any preceding object or spawn at top
			Globals.grid [gridPosition [0], gridPosition [1]] = gameObject;
		} else {
			//if it is end of grid. take a life and destroy object
			GameObject.Find ("Control").BroadcastMessage("enemyHitTower", gameObject);
		}
		Debug.Log (Globals.grid[2,6]);
		Debug.Log (Globals.grid[2,5]);

	}

	public void SetGridPosition(int[] gridP){
		gridPosition = gridP;
	}

	public void updateTick(){
		//target = new Vector3 (target.x, target.y - Globals.gridYSpacing, target.z);

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
