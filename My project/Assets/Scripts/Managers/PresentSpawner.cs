using System.Collections;
using UnityEngine;

public class PresentSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] presentPrefabs;

    [SerializeField] GameEvent spawnPresentEvent;

    [SerializeField] GameObject presentSpawnVFX;

    [SerializeField] float maximumX;
    [SerializeField] float maximumZ;
    [SerializeField] float axisOffset = 1f;

    GameObject[] instanciatedPresents;

    WaitForSeconds waitForSeconds;

    Vector3 vector3;

    float randomX;
    float randomZ;

    int randomPresent;

    bool isInitCalled = false;


    private void Start()
    {
        waitForSeconds = new WaitForSeconds(.5f);
        instanciatedPresents = new GameObject[5];
        InitRandomLocation();
    }

    public void RandomPresentEnabler()
    {
        Debug.Log("Called");
        GetRandomV3();
        randomPresent = Random.Range(0, presentPrefabs.Length);
        Debug.Log($"Randon is {randomPresent}");
        instanciatedPresents[randomPresent].transform.position = vector3;
        presentSpawnVFX.transform.position = vector3;
        spawnPresentEvent.Raise();
    }

    public void PlayEffect()
    {
        Instantiate(presentSpawnVFX, vector3, presentSpawnVFX.transform.rotation);
    }

    public void Spawn()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        yield return waitForSeconds;
        instanciatedPresents[randomPresent].SetActive(true);
    }

    void InitRandomLocation()
    {
        if (!isInitCalled)
        {
            randomPresent = Random.Range(0, presentPrefabs.Length);

            for (int i = 0; i < presentPrefabs.Length; i++)
            {
                GetRandomV3();

                instanciatedPresents[i] = Instantiate(presentPrefabs[i], vector3, presentPrefabs[i].transform.rotation);

                if (!(i == randomPresent))
                {
                    instanciatedPresents[i].SetActive(false);
                }
            }
            isInitCalled = true;
        }
    }

    private void GetRandomV3()
    {
        randomX = Random.Range(-maximumX + axisOffset, maximumX - axisOffset);
        randomZ = Random.Range(-maximumZ + axisOffset, maximumZ - axisOffset);

        vector3 = new Vector3(randomX, .2f, randomZ);
    }
}
