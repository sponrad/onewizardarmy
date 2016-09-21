using UnityEngine;
using System.Collections;

public class l02ProjectileScript : MonoBehaviour {

	public float speed;
	public enum Type {all, none, lightning, water, ice, normal, fire};
	public Type type;

	public bool splitOnMatch = false;
	public bool explodeOnMatch = false;
	public bool iceProjectile = false;
	public int stunDuration = 0;
	public Type spreadTo;
	public Type destroyType;

	private bool preventDestroy = false;

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 3f);  //really horribly designed cleanup
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position += transform.up * step;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "enemy") {
			
			if (stunDuration > 0) {
				coll.gameObject.BroadcastMessage ("stunned", stunDuration);
				Destroy (gameObject);
			}

			if (spreadTo.ToString() == coll.gameObject.GetComponent<l02MonsterScript> ().type.ToString ()) {
				
			}
				
			if (coll.gameObject.GetComponent<l02MonsterScript> ().type.ToString () == type.ToString ()) {
				if (explodeOnMatch) {
					explodeProjectile ();
					Destroy (coll.gameObject);
				}

				if (splitOnMatch) {
					splitProjectile (coll.gameObject.transform);
					Destroy (coll.gameObject);
					Destroy (gameObject);
				}

			}

			if (destroyType.ToString() == coll.gameObject.GetComponent<l02MonsterScript> ().type.ToString ()) {
				Destroy (coll.gameObject);
				Destroy (gameObject);
			}

			if (destroyType.ToString () == "all") {
				Destroy (coll.gameObject);
				if (!preventDestroy) {
					Destroy (gameObject);
				}
			}

			//trigger Fall on all enemeis
			GameObject.Find("Control").BroadcastMessage("EnemiesFallDown");
		}
	}

	void explodeProjectile(){
		//take out the surrounding objects.
		Debug.Log("FIRE");
		transform.localScale = new Vector3(5f, 5f, 5f);
		speed = 0f;
		preventDestroy = true;
		Invoke ("destroy", .3f);
	}

	void splitProjectile(Transform target){
		//create two projectiles of this same type behind it.. going diagonally
		Instantiate(gameObject, new Vector3(target.position.x, target.position.y, target.position.z), Quaternion.Euler( new Vector3(0f, 0f, 50f)));
		Instantiate(gameObject, new Vector3(target.position.x, target.position.y, target.position.z), Quaternion.Euler( new Vector3(0f, 0f, -50f)));
	}

	void iceExplode(){
		Debug.Log("ICE");
		transform.localScale = new Vector3(5f, 5f, 5f);
		speed = 0f;
	}

	void destroy(){
		Destroy (gameObject);
	}
}