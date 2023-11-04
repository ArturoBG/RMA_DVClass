using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goblinPrefab;

    public int timeToSpawn;

    private void Start()
    {
        SpawnGoblin();
    }

    public void SpawnGoblin()
    {
        StartCoroutine(spawnGoblinRoutin());
    }

    IEnumerator spawnGoblinRoutin()
    {
        float timer = 0;

        while (true)
        {
            if (timer >= timeToSpawn)
            {
                Instantiate(goblinPrefab,transform.position, transform.rotation);
                timer = 0f;
            }
            timer += Time.deltaTime;

            yield return null;
        }
    }
}
