using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * User Interface controller for Overworld by Joshua Medernach
 */

public class OverworldUI : MonoBehaviour {

	public Canvas overworldUI;
	public Canvas pauseMenu;
	public Button leftArrow;
	public Button rightArrow;
	public Button pauseButton;

	public OverworldPlayerController controller;

	private bool leftPress = false;
	private bool rightPress = false;

	// Use this for initialization
	void Start () {
		overworldUI = overworldUI.GetComponent<Canvas> ();
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		leftArrow = leftArrow.GetComponent<Button> ();
		rightArrow = rightArrow.GetComponent<Button> ();
		pauseButton = pauseButton.GetComponent<Button> ();
		controller = controller.GetComponent<OverworldPlayerController> ();

		pauseMenu.enabled = false;
	}

	void Update() {
		if (leftPress) {
			controller.applyMovement(-1);
		}
		if (rightPress) {
			controller.applyMovement(1);
		}
	}
	
	public void PausePress() {
		Time.timeScale = 0;
		overworldUI.enabled = false;
		pauseMenu.enabled = true;
	}

	public void ResumePress() {
		Time.timeScale = 1;
		overworldUI.enabled = true;
		pauseMenu.enabled = false;
	}

	public void QuitPress() {
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}

	public void LeftPress() {
		leftPress = true;
	}

	public void RightPress() {
		rightPress = true;
	}

	public void LeftDepress() {
		leftPress = false;
	}
	
	public void RightDepress() {
		rightPress = false;
	}
}
