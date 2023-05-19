using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Score score;

    [SerializeField] GameEvent presentCollisionEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddScore();
        }
    }

    public void AddScore()
    {
        score.AddScore(1);
    }

    public void GameOverDebug()
    {
        Debug.Log("GameOver");
    }

    void CheckScoreDebug()
    {
        Debug.Log(score.score);
    }

    private void OnDisable()
    {
        score.ResetScore();
    }

}
