using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public MenuManager pauseMenu;
	
	public void exitGame()
	{
		Application.Quit();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
		}
    }
}
