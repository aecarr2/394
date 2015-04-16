using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {
	
	public GUIText scoreDisplay;
	static int score = 0;
	static float cooldown = 0;

	Transform player;
	float offsetX;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if (player_go == null) {
			Debug.LogError ("Couldn't find an object with tag 'Player!'");
			return;
		}

		player = player_go.transform;

		offsetX = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}

	// checks whether the cooldown has finished before updating
	// the cooldown may be needed since you start stacking the clouds on each other at some point in the level
	public void IncrementScore () {
		if (cooldown <= 0) {
			score++;
			cooldown = 0.5f;
		}
		scoreDisplay.text = "Score: " + score;
	}
}
