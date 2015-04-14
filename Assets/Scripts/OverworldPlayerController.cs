using UnityEngine;
using System.Collections;

public class OverworldPlayerController : MonoBehaviour {

	public float speed;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		
		Vector2 movement = new Vector2(moveHorizontal, 0);
		
		GetComponent<Rigidbody2D>().AddForce(movement * speed * Time.deltaTime);
	}
}