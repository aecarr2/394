using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	float flySpeed = 100f;
	float forwardSpeed = 2f;

	bool didFly = false;
	bool dead = false;

	public bool godMode = false;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
	}

	// Do Graphic and Input updates here
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			didFly = true;
		}


	}
	
	// Do physics engine updates here
	void FixedUpdate () {

		if(dead) {
			return;
		}

		GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
	
		if (didFly) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * flySpeed);

			animator.SetTrigger("Fly");

			didFly = false;
		}
		/*if (GetComponent<Rigidbody2D> ().velocity.y > 0)
			transform.rotation = Quaternion.Euler (0, 0, 0);
		else {
			float angle = Mathf.Lerp (0, -90, (-GetComponent<Rigidbody2D> ().velocity.y / 3f));
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}*/

	}
	void OnCollisionEnter2D(Collision2D collision){
		if(godMode)
			return;

		animator.SetTrigger("Death");
		dead = true;
	}


}
