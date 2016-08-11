using UnityEngine;
using System.Collections;

public class TowerColliderScript : MonoBehaviour {

	public GameObject control;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.tag == "enemy") {
			//kill the enemy... and
			control.BroadcastMessage("enemyHitTower", coll.gameObject);
		}
	}
}
