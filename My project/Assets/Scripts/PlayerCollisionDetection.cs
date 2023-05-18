using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] GameEvent presentCollisionEvent;
    [SerializeField] GameEvent GameOverEvent; 

    const string SCORE_LAYER_NAME = "Score";
    const string PLAYER_LAYER_NAME = "Player";
    const string BOUND_LAYER_NAME = "Bound";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(SCORE_LAYER_NAME))
        {
            presentCollisionEvent.Raise();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER_NAME))
        {
            GameOverEvent.Raise();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer(BOUND_LAYER_NAME))
        {
            GameOverEvent.Raise();
        }
    }
}
