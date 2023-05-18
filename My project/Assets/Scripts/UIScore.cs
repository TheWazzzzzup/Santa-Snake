using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI scoreText;
    
    
    private void FixedUpdate()
    {
        scoreText.text = score.score.ToString();
    }
}
