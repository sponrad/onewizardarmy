﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GambleTowerScript : MonoBehaviour {

	public GameObject projectile;

	public int coolingDown = 0;
	public int cooldown = 4;
	public bool entireRow = false;
	public enum Type {lightning, water, ice, normal, fire};
	public Type type;
	public List<Globals.towerGambleTypes> towerFireOptions;
	public Sprite[] iconSprites;
	public bool gambleTower = false;
	public bool columnAimed = false;

	private int fireOption = 0;
	private SpriteRenderer sr;
	private Vector3 aimedFirePosition;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		aimedFirePosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (coolingDown == 0) {
			//tower is chosen, if columnaimed tower then bring up the column aimer
			//else proceed to the nonaimed
			if (columnAimed) {
				activateColumnAimer ();
				//towerActivateInit ();
			} else {
				towerActivateInit ();
			}
		}
	}

	void activateColumnAimer(){
		//provide callback to this gameObject?
		GameObject.Find("Control").BroadcastMessage("showColumnAimer", gameObject);
	}
		
	public void SetTargetAndFire(int column){
		//column is 0 through 4
		float xPos = 0f;
		xPos = Globals.towerLeftXPos + (column * Globals.gridXSpacing);
		aimedFirePosition = new Vector3 (xPos, transform.position.y, transform.position.z);

		towerActivateInit ();
	}

	void towerActivateInit(){
		//make unable to fire twice, add gray cooldown color after firing
		coolingDown = cooldown;

		if (gambleTower){
			gambleAndActivateTower();   //function that will control the animation and determine an option based on fireoptions and sprites
		}
		else{
			fireOption = 1;
			activateTower ();
		}
	}

	void activateTower(){
		//in this case fireOptions[] is always an integer so we are just spawning that many projectiles
		// find the fire option from towergambleoptions list, and do that!
		switch (towerFireOptions [fireOption].ToString ()) {
		case "fire1":
			fireProjectile (1);
			break;
		case "fire2":
			fireProjectile (2);
			break;
		case "fire3":
			fireProjectile (3);
			break;
		case "powerup":
			break;
		case "cooldown":
			break;
		case "misfire":
			break;
		default:
			break;
		}
			
		gameObject.GetComponent<SpriteRenderer> ().color = Color.gray;
			
		//TODO: do not tell control we have fired until all animations play... Co-routine?
		//tell control that we have fired a tower... have it check for tower cooldowns and move enemies if needed
		GameObject.Find("Control").BroadcastMessage("towerFired");

	}

	void finishCooldown (){
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	public void gambleAndActivateTower(){
		//cycle through all of the images for a while
		StartCoroutine(gambleSprites());
	}

	public void tick(){
		//TODO: change image based on cooldown remaining

		if (coolingDown > 0) {
			coolingDown -= 1;

			if (coolingDown == 0) {
				finishCooldown ();
			}
		}
	}

	IEnumerator gambleSprites(){
		List<Sprite> tempSprites = iconSprites.ToList();

		//choose the final image
		fireOption = Random.Range(0, towerFireOptions.Count-1);
		Debug.Log (fireOption);

		//reorder the tempSprites so that the final one is at the end
		//number of times to pop and move the sprites equals length minus the fireOption
		int itemsToReorder = towerFireOptions.Count - 1 - fireOption;
		while (itemsToReorder != 0) {
			Sprite tempSprite = tempSprites [tempSprites.Count - 1];
			tempSprites.RemoveAt (tempSprites.Count - 1);
			tempSprites.Insert (0, tempSprite);

			itemsToReorder -= 1;
			Debug.Log(itemsToReorder);
		}
			
		for (int i = 0; i < tempSprites.Count; i++){
			//waitTime increases as j increases
			float waitTime = (i * 0.05f) + 0.05f;
			yield return new WaitForSeconds (waitTime);

			sr.sprite = tempSprites[i];
		}

		//sr.sprite = iconSprites [fireOption];
		activateTower ();
	}

	public void fireProjectile(int count){
		for (int x = 0; x < count; x++) {
			if (entireRow) {
				for (float i = -2.6f; i < 3f; i += 1.3f) {
					Instantiate (projectile, new Vector3 (i, transform.position.y, transform.position.z), Quaternion.identity);
				}
			} else {
				Instantiate (projectile, aimedFirePosition, Quaternion.identity);
			}
		}
	}
}
