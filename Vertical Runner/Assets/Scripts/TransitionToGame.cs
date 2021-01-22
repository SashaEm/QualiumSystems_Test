using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToGame : MonoBehaviour
{
    public void StartGame()
    {
        var gameSceneId = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(gameSceneId);
    }
}
