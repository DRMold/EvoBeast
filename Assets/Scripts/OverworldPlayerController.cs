using UnityEngine;
using System.Collections;

/* Scripted by Joshua Medernach
 * Gives the player the ability to move around the overworld via a player avatar
 */ 

public class OverworldPlayerController : MonoBehaviour {

	//public float speed = 200;
	public int level = -1;
	public GameObject player;

	/* For each frame of the Game, the input is gathered and controls the 
	 * onscreen avatar.
	 *
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		applyMovement (moveHorizontal);
	}
	*/

	public void applyMovement(float moveHorizontal) {
		//Vector2 movement = new Vector2(moveHorizontal, 0);
		
		//GetComponent<Rigidbody2D>().AddForce(movement * speed * Time.deltaTime);

		level = level + (int)moveHorizontal;

		if (level < -1) {
			level = -1;     // Minimum level cap
		} 
		else if (level > 1) {
			level = 1; // Maximum level cap
		}
		else {
			// assumes moveHorizontal is either -1 or 1
			Vector3 move = new Vector3 (moveHorizontal*150, 0, 0);

			player.transform.Translate (move, Space.World);
		}
	}
}