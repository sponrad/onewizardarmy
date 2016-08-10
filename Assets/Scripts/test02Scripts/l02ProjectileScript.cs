using UnityEngine;
using System.Collections;

public class l02ProjectileScript : MonoBehaviour {

	public float speed;
	public enum Type {lightning, water, ice, normal, fire};
	public Type type;

	public bool splitOnMatch = false;
	public bool explodeOnMatch = false;
	public bool iceProjectile = false;

	private bool preventDestroy = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position += transform.up * step;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "enemy") {

			if (coll.gameObject.GetComponent<l02MonsterScript> ().type.ToString () == type.ToString ()) {
				if (explodeOnMatch) {
					explodeProjectile ();
					Destroy (coll.gameObject);
				}

				if (splitOnMatch) {
					splitProjectile ();
					Destroy (coll.gameObject);
					Destroy (gameObject);
				}

			} else {
				Destroy (coll.gameObject);
				if (!preventDestroy) {
					Destroy (gameObject);
				}
			}
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

	void splitProjectile(){
		//create two projectiles of this same type behind it.. going diagonally
		Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler( new Vector3(0f, 0f, 45f)));
		Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler( new Vector3(0f, 0f, -45f)));
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