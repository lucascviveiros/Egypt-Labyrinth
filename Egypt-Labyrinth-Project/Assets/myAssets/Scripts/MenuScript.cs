using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Button btnStart; 
	public Button btnExit;
	public GameObject pauseMenuUI;
	public static bool GameIsPaused = false;

	void Start () 
	{
		Button btn = btnStart.GetComponent<Button>();
        	btn.onClick.AddListener(StartGame);

		Button btn2 = btnExit.GetComponent<Button>();
        	btn2.onClick.AddListener(ExitGame);
		
	}

	private void StartGame(){
		SceneManager.LoadScene("scene-1");
	}

	void Update() {
		if (Input.GetKey(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else {
				Pause();
			}
		}
	}

	void Resume() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause() {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
	}

	private void ExitGame() 
	{
	#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
	}

}
