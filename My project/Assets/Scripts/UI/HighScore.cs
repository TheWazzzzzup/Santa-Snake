using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI text;

    private void OnEnable()
    {
        text.text = "Score: " + score.score.ToString();
    }
}
