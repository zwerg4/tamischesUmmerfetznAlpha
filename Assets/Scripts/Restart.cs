using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
   public void RestartGame() 
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // loads current scene
     LapTimeManager.MinuteCount = 0;
     LapTimeManager.SecondCount = 0;
     LapTimeManager.MilliCount = 0;
   }
}
