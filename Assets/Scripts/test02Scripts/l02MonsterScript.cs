using UnityEngine;
using System.Collections;

public class l02MonsterScript : MonoBehaviour {

	public float speed = 4.0f;

	public Vector3 target;

	// Use this for initialization
	void Start () {
		target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target, step);
	}

	public void updateTick(){
		target = new Vector3 (target.x, target.y - 1.5f, target.z);
	}

	public void OnDestroy(){
		GameObject.Find ("Control").GetComponent<l02Control> ().enemyList.Remove (gameObject);
	}
}
