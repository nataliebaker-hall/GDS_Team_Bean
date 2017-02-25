using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour 
{
	// Variables
	public bool game_running = false;
	public CanvasGroup LoseGame;
	public CanvasGroup WinGame;
	public CanvasGroup Menu;
	public CanvasGroup Info;

	public void Start ()
	{
		// Initialise Canvas Variables
		LoseGame = GameObject.Find ("Game_Over").GetComponent<CanvasGroup> ();
		WinGame = GameObject.Find ("Win_Game").GetComponent<CanvasGroup> ();
		Menu = GameObject.Find ("Menu").GetComponent<CanvasGroup> ();
		Info = GameObject.Find ("Info").GetComponent<CanvasGroup> ();
	}

	public void StartGame () 
	{
		// When 'Start' button pressed, menu disappears
		Menu.alpha = 0;
		// Game Starts
		game_running = true;
	}

	public void Info_Button()
	{
		if (Menu.alpha == 1 && Info.alpha == 0) 
		{
			Menu.alpha = 0;
			Info.alpha = 1;
		}
	}

	public void Back_Button()
	{
		if (Menu.alpha == 0 && Info.alpha == 1) 
		{
			Menu.alpha = 1;
			Info.alpha = 0;
		}
	}

	public void QuitGame()
	{
		// If any of the canvases are visible and 'Quit' button pressed, end the game
		if (LoseGame.alpha == 1 || WinGame.alpha == 1 || Menu.alpha == 1) 
		{
			Application.Quit();
		}
	}

	public void Restart()
	{
		// If 'LoseGame' canvas or 'WinGame' canvas is active and 'Restart' button pressed, reload the scene
		if (LoseGame.alpha == 1 || WinGame.alpha == 1) 
		{
			SceneManager.LoadScene ("Game");
		}
	}

}
