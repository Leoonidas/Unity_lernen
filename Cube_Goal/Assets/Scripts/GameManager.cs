using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int CurrentLevelIndex = 0;

    public void LoadNextLevel()
    {
        Debug.Log("Next level loaded.");

        SceneManager.LoadScene(CurrentLevelIndex + 1);

    }


}
