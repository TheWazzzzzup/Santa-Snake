using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Score score;

    public void RestartGame()
    {
        score.ResetScore();

        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadSceneAsync(0);
    }

}
