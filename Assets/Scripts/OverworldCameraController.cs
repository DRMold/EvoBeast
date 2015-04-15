using UnityEngine;
using System.Collections;

/* Scripted by Joshua Medernach
 * Attaches the Overworld camera to the player object in the Overworld
 */ 

public class OverworldCameraController : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;

	/*Grab the camera's initial position*/

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}

	/* For each frame of the Game, the camera's position is updated
	 * giving the player an illusion that the camera is following the
	 * player */

	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}