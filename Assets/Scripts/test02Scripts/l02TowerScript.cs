using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class l02TowerScript : MonoBehaviour {

	public GameObject projectile;

	public int coolingDown = 0;
	public int cooldown = 4;
	public bool entireRow = false;
	public enum Type {lightning, water, ice, normal, fire};
	public Type type;
	public int[] fireOptions = new int[] {0, 1, 1, 1, 1, 1, 1, 1, 1, 5};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//if this tower is available... FIRE!!!!
		if (coolingDown == 0) {
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
		coolingDown = cooldown;

		//TODO: do not spawn next row until all animations play
		GameObject.Find ("Control").BroadcastMessage ("spawnEnemyRow");

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("tower");
		for (int i = 0; i < towers.Length; i++) {
			towers [i].BroadcastMessage("tick");
		}

		Debug.Log (type);
	}

	void finishCooldown (){
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	public void tick(){
		if (coolingDown > 0) {
			coolingDown -= 1;

			if (coolingDown == 0) {
				finishCooldown ();
			}
		}

	}
}
