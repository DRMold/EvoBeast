using UnityEngine;
using System.Collections;

[System.Serializable] 
public class Boundary 
{ public float xMin, xMax, yMin, yMax; }

public class Player_Controller : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;
	private Game_Controller gameController;
	
	// Use this for initialization
	void Start () 
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{ gameController = gameControllerObject.GetComponent<Game_Controller> (); }
		else { Debug.Log ("Cannot find 'GameController' script."); }
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if(Input.GetKey(KeyCode.LeftArrow)) {
		//	// left
		//	transform.Rotate(0.0f, 0.0f, 5.0f);  // does nothing, just a bad guess
		//}
		
		//if(Input.GetKey(KeyCode.RightArrow)) {
			// right
		//	transform.Rotate(0.0f, 0.0f, -5.0f);  // does nothing, just a bad guess
		//}
		
	}
	
	void FixedUpdate()  
	{
		//pick up movement from user input
		float moveHorizontal = Input.GetAxis("Horizontal");
		
		//calculates where and how quickly the player moves
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		//GetComponent<Rigidbody2D>().velocity = movement * speed;
		GetComponent<Rigidbody2D>().AddForce(movement * speed * Time.deltaTime);

		GetComponent<Rigidbody2D>().position = new Vector2
			(
				Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
			);
	}

	void OnCollision2D(Collider2D other)
	{
		if (other.tag == "Finish" && this.GetComponent<Rigidbody2D>().velocity.y > 5)
		{
			this.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Assets/Sprites/New_Sprites/Broken egg") as Sprite;
			gameController.GameOver();
		}
	}
}
