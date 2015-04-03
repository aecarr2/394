using UnityEngine;
using System.Collections;

public class BGLooperScript : MonoBehaviour {

	int numBGPanels = 6;

	float cloudMax = 4.81f;
	float cloudMin = 3.12f;

	void Start(){
		GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");

		foreach (GameObject cloud in clouds) {
			Vector3 pos = cloud.transform.position;
			pos.y = Random.Range(cloudMin, cloudMax);
			cloud.transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Triggered: " + collider.name);

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += widthOfBGObject * numBGPanels;

		if(collider.tag == "Cloud") {
			pos.y = Random.Range(cloudMin, cloudMax);
		}
		collider.transform.position = pos;

	}
}


