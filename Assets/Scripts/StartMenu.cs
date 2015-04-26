using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Programmed by Joshua Medernach

public class StartMenu : MonoBehaviour {

	// A place to refer to our buttons
	public Button start;
	public Button levelLoad;
	public Button credits;
	public Button quit;

	public Canvas creditMenu;
	public Canvas startMenu;

	// Use this for initialization
	void Start () {
		start = start.GetComponent<Button> ();
		levelLoad = levelLoad.GetComponent<Button> ();
		credits = credits.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();

		creditMenu = creditMenu.GetComponent<Canvas> ();
		creditMenu.enabled = false;

		startMenu = startMenu.GetComponent<Canvas> ();
	}

	public void StartGame()
	{ Application.LoadLevel (2); }

	// The load level button is pressed
	public void StartOverworld() {
		Application.LoadLevel (1); // This loads the Overworld scene
	}

	// The quit button is pressed
	public void QuitGame() {
		Application.Quit ();
	}

	// The credits button is pressed
	public void Credit() {
		creditMenu.enabled = true;
		startMenu.enabled = false;
	}

	// The back button in credits is pressed
	public void Back() {
		creditMenu.enabled = false;
		startMenu.enabled = true;
	}
}
