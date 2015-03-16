using UnityEngine;
using System.Collections;

[System.Serializable] 
public class Boundary 
{ public float xMin, xMax, yMin, yMax; }

public class Player_Controller : MonoBehaviour {
	public float speed;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()  
	{
		//pick up movement from user input
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		//calculates where and how quickly the ship moves
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		GetComponent<Rigidbody2D>().velocity = movement * speed;
		
		GetComponent<Rigidbody2D>().position = new Vector2
			(
				Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
			);	
	}
}
