using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LevelUI : MonoBehaviour 
{

	public Canvas levelUI;
	public Canvas pauseMenu;
	public Canvas gameOverMenu;
	public Button leftArrow;
	public Button rightArrow;
	public Button pauseButton;

	public Player_Controller playerController;
	public Game_Controller gameController;

	private bool leftPress = false;
	private bool rightPress = false;

	// Use this for initialization
	void Start ()
	{
		levelUI = levelUI.GetComponent<Canvas> ();
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		gameOverMenu = gameOverMenu.GetComponent<Canvas>();
		leftArrow = leftArrow.GetComponent<Button> ();
		rightArrow = rightArrow.GetComponent<Button> ();
		pauseButton = pauseButton.GetComponent<Button> ();
		playerController = playerController.GetComponent<Player_Controller> ();
		gameController = gameController.GetComponent<Game_Controller> ();

		pauseMenu.enabled = false;
		gameOverMenu.enabled = false;
	}

	void Update() 
	{
		if (leftPress) {
			playerController.applyMovement(-1);
		}
		if (rightPress) {
			playerController.applyMovement(1);
		}
		if (gameController.getGameOver())
		{
			levelUI.enabled = false;
			gameOverMenu.enabled = true;
		}
	}
	
	public void PausePress() 
	{
		gameController.Pause();
		levelUI.enabled = false;
		pauseMenu.enabled = true;
	}

	public void ResumePress() 
	{
		gameController.Pause ();
		levelUI.enabled = true;
		pauseMenu.enabled = false;
	}

	public void RetryPress()
	{ Application.LoadLevel (Application.loadedLevel); }

	public void QuitPress() 
	{
		gameController.Pause();
		Application.LoadLevel (1);
	}

	public void LeftPress() 
	{ leftPress = true; }

	public void RightPress() 
	{ rightPress = true; }

	public void LeftDepress() 
	{ leftPress = false; }
	
	public void RightDepress() 
	{ rightPress = false; }
}
