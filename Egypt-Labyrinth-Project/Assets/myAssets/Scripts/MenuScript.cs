using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Button btnStart; 
	public Button btnExit;

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

	private void ExitGame() 
	{
	#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
	}

}
