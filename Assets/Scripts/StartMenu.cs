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

	// Use this for initialization
	void Start () {
		start = start.GetComponent<Button> ();
		levelLoad = levelLoad.GetComponent<Button> ();
		credits = credits.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
	}

	// The start button is pressed
	public void StartOverworld() {
		Application.LoadLevel (1); // This loads the Overworld scene
	}

	// The quit button is pressed
	public void QuitGame() {
		Application.Quit ();
	}
}
