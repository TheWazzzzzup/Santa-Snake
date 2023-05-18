using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCollision : MonoBehaviour
{
    [SerializeField] GameEvent collisionEvent;
    [SerializeField] GameEvent GameOverEvent; 

    string SCORE_LAYER_NAME = "Score";
    string PLAYER_LAYER_NAME = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(SCORE_LAYER_NAME))
        {
            collisionEvent.Raise();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER_NAME))
        {
            GameOverEvent.Raise();
        }
    }
}
