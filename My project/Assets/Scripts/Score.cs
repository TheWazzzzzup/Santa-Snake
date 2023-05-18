using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableScore")]
public class Score : ScriptableObject
{
    public uint score { get; set; } = 0;



    public void AddScore(uint x)
    {
        score += x;
    }
    
    public void ResetScore()
    {
        score = 0;
    }
}
