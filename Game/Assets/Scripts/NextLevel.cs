using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void ReloadScene()
    {
    	SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
    	Debug.Log("EndGame!");
    	Application.Quit();
    }
}
