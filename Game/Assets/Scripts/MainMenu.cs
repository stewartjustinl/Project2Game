using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // SceneManager.LoadScene("levelName"); // this option will be used if we want to manually tell the play button what scene to load
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // we will use this option if we want to setup loading scenes by indexing
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame!");
        Application.Quit();
    }
}
