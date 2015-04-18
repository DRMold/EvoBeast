using UnityEngine;
using System.Collections;

public class Game_Controller : MonoBehaviour
{
	public GameObject cloud;
	public Vector3 spawnValues;
	public int cloudCount;
	public float spawnWait, startWait, waveWait;

	public GUIText scoreText; //GUIText displays on Viewport space, using 0-1 values; Game displays using pixels in seperate space.
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private bool paused;
	private int score;

	// Use this for initialization
	void Start () 
	{
		gameOver = false;
		restart = false;
		paused = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		StartCoroutine(SpawnClouds());
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{ Application.LoadLevel (Application.loadedLevel); }
		}
		if(Input.GetKeyUp(KeyCode.P))
		{
			paused = !paused;
		}
		
		if(paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	IEnumerator SpawnClouds() 
	{
		yield return new WaitForSeconds(startWait);
		while (true) 
		{
			yield return new WaitForSeconds(waveWait);
			for (int i = 0; i < cloudCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (10, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (cloud, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait); // can only be used with a yield statement in coroutines; without would pause whole game
			}
			
			if (gameOver)
			{ 
				restartText.text = "Press 'R' to restart.";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{ 
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{ scoreText.text = "Score: " + score; } //scoreText.text is text box in inspector on GUIText component
	
	public void GameOver()
	{
		gameOver = true;
		gameOverText.text = "Game Over!";
	} 
}
