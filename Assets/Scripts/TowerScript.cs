using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {

	public GameObject projectile;

	public bool coolingDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log (this.name);
		//if this tower is available... FIRE!!!!
		if (!coolingDown) {
			Instantiate (projectile, transform.position, Quaternion.identity);
		}

	}
}
