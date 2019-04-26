using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenuUI;
	public static bool GameIsPaused = false;
	private AudioSource m_EgyptMusic;

	// Use this for initialization
	void Start () {

		AudioSource m_EgyptMusic = GetComponent<AudioSource>();
		m_EgyptMusic.Play();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
	}

	public void Exit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}
}
