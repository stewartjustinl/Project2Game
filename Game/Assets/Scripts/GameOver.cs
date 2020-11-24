using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void MainMenu()
   {
   		SceneManager.LoadScene(0);
   }

   public void NewGame()
   {
   		SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
   		Debug.Log("QuitingGame!");
   		Application.Quit();
   }
}
