using UnityEngine;
using System.Collections;

public class l02ProjectileScript : MonoBehaviour {

	public float speed;

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

			Destroy (coll.gameObject);
			Destroy (gameObject);
		}
	}
}
