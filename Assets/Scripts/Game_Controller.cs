using UnityEngine;
using System.Collections;

public class Game_Controller : MonoBehaviour
{
	public GameObject cloud;
	public Vector3 spawnValues;
	public int cloudCount;
	public float spawnWait, startWait, waveWait;

	private bool gameOver;
	private bool paused;
	private int score;

	// Use this for initialization
	void Start () 
	{
		gameOver = false;
		paused = false;
		score = 0;
		StartCoroutine(SpawnClouds());
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.P))
		{
			Pause();
		}
		
		if (paused || gameOver)
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
			{ break; }
		}
	}

	public void AddScore(int newScoreValue)
	{ 
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{ /*scoreText.text = "Score: " + score; */} //scoreText.text is text box in inspector on GUIText component
	
	public void GameOver()
	{ gameOver = true; } 

	public void Pause()
	{ this.paused = !this.paused; }

	
	public void Finish() { StartCoroutine(BeatGame()); }
	IEnumerator BeatGame()
	{
		yield return new WaitForSeconds(5);
		Application.LoadLevel(1);
	}

	public bool getGameOver()
	{ return gameOver; }
}
