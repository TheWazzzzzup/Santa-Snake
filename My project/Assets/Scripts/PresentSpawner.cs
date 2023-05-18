using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] presentPrefabs;

    [SerializeField] GameEventListener presentCollisionEventListener;

    [SerializeField] float maximumX;
    [SerializeField] float maximumZ;




    void ChooseRandomLocation()
    {

    }
}
