using UnityEngine;
using System.Collections;

public class SpritePicker : MonoBehaviour {

	// This script randomly picks a sprite from the array clouds[]
	// Note that you'll have to update the two clouds in the prefab independently
	// if you change the set of sprites they use

	public Sprite[] clouds;
	public SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer.sprite = clouds [Mathf.FloorToInt (Random.value * clouds.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
