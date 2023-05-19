using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableScore")]
public class Score : ScriptableObject
{
    [SerializeField] GameEvent targetScoreEvent;


    public uint score { get; set; } = 0;


    public void AddScore(uint x)
    {
        score += x;

        if (targetScoreEvent != null && score % 10 == 0)
        {
            targetScoreEvent.Raise();
        }
    }
    
    public void ResetScore()
    {
        score = 0;
    }


}
