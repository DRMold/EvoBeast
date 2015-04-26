using UnityEngine;
using System.Collections;

[System.Serializable] 
public class Boundary 
{ public float xMin, xMax, yMin, yMax; }

public class Player_Controller : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;
	public Sprite sprite1; // Default Sprite
	public Sprite sprite2; // Failure Sprite
	public Sprite sprite3; //Victory Sprite
	public GameObject dragon;

	private SpriteRenderer spR;
	private Game_Controller gameController;
	
	// Use this for initialization
	void Start () 
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{ gameController = gameControllerObject.GetComponent<Game_Controller> (); }
		else { Debug.Log ("Cannot find 'GameController' script."); }

		spR = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spR.sprite == null) 			  // if the sprite on spriteRenderer is null then
			spR.sprite = sprite1;			  // set the sprite to default
	}
	
	void FixedUpdate()  
	{
		//pick up movement from user input
		float moveHorizontal = Input.GetAxis("Horizontal");
		applyMovement (moveHorizontal);
	}
	
	public void applyMovement(float moveHorizontal) 
	{		
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

	void OnCollisionEnter2D(Collision2D coll)
	{
		Vector3 offSet = new Vector3 (0, -1, 0);
		if (coll.relativeVelocity.magnitude > 25)
		{
			spR.sprite = sprite2;
			transform.rotation = Quaternion.identity;
			gameController.GameOver();
		}
		else if (coll.gameObject.tag == "Finish" && spR.sprite == sprite1)
		{ 
			spR.sprite = sprite3;
			transform.rotation = Quaternion.identity;
			Instantiate (dragon, this.transform.position - offSet, this.transform.rotation);
			gameController.Finish();
		}
	}
}
