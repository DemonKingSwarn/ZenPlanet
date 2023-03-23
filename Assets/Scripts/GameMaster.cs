using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
   public void GoToGameScene()
   {
	SceneManager.LoadScene("Main");
   }

   public void Restart()
   {
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void GoToMainMenu()
   {
	SceneManager.LoadScene("MainMenu");
   }
}
