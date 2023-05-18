using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Score score;

    [SerializeField] GameEvent presentCollisionEvent;

    public void AddScore()
    {
        Debug.Log(score.score);
        score.AddScore(1);
    }
    public void GameOverDebug()
    {
        Debug.Log("GameOver");
    }

    [ContextMenu("CheckScore")]
    void CheckScore()
    {
        Debug.Log(score.score);
    }

    private void OnDisable()
    {
        score.ResetScore();
    }

}
