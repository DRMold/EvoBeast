using UnityEngine;
using System.Collections;

/* Scripted by Joshua Medernach
 * Gives the player the ability to move around the overworld via a player avatar
 */ 

public class OverworldPlayerController : MonoBehaviour {

	public float speed = 200;

	/* For each frame of the Game, the input is gathered and controls the 
	 * onscreen avatar.
	 */
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		
		Vector2 movement = new Vector2(moveHorizontal, 0);
		
		GetComponent<Rigidbody2D>().AddForce(movement * speed * Time.deltaTime);
	}
}