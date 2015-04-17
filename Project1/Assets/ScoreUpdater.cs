using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {

	// This allows the extra collider I added to the cloud prefab to increment the score

	CameraTracksPlayer tracks;

	// Use this for initialization
	void Start () {
		// grab the main camera, and get the component from it
		tracks = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTracksPlayer>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		// if the player hits the collider, notify the camera's script.
		if (collider.tag == "Player")
			tracks.IncrementScore();
	}
}
