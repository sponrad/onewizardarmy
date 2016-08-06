using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class l01TowerScript : MonoBehaviour {

	public GameObject projectile;

	public bool coolingDown = false;
	public float cooldown = 4f;
	public bool entireRow = false;
	public int[] fireOptions = new int[] {0, 1, 1, 1, 1, 1, 1, 1, 1, 5};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//if this tower is available... FIRE!!!!
		if (!coolingDown) {
			fire ();
		}
	}

	void fire(){

		int fireOption = fireOptions[Random.Range (0, fireOptions.Length)];

		for (int x = 0; x < fireOption; x++) {
			if (entireRow) {
				for (float i = -2.6f; i < 3f; i += 1.3f) {
					Instantiate (projectile, new Vector3 (i, transform.position.y, transform.position.z), Quaternion.identity);
				}
			} else {
				Instantiate (projectile, transform.position, Quaternion.identity);
			}
		}

		gameObject.GetComponent<SpriteRenderer> ().color = Color.gray;
		coolingDown = true;

		Invoke ("finishCooldown", cooldown);
	}

	void finishCooldown (){
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		coolingDown = false;
	}
}
