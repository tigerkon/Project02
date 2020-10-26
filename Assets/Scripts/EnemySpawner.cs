using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;                // The prefab to be spawned.


    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Debug.Log(true);

            Vector3 spawnPosition = new Vector3(Random.Range(-5f,5f), Random.Range(1f,2f), Random.Range(-5f,5f));
            GameObject newEnemy = (GameObject)Instantiate(enemyObject, spawnPosition, Quaternion.Euler(0, 0, 0));
        }
    }



}
