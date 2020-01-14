using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public float timer;
    public float orbSpawnTime;

    public GameObject orbPrefab;
    public GameObject orbsParent;

    public int spawnRow;
    public int spawnLocation;

    public Transform[] orbSpawnTransform0;
    public Transform[] orbSpawnTransform1;
    public Transform[] orbSpawnTransform2;
    public Transform[] orbSpawnTransform3;

    public GameObject[] floatingOrbs;
    public int orbsActive;
    public int orbLimit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        floatingOrbs = GameObject.FindGameObjectsWithTag("Orb");

        orbsActive = floatingOrbs.Length;

        if (orbsActive < orbLimit)
        timer += Time.deltaTime;

        if (orbSpawnTime < timer)
        {
            spawnRow = Random.Range(0, 3);

            if (spawnRow == 0)
            {
                spawnLocation = Random.Range(0, 7);
                Instantiate(orbPrefab, orbSpawnTransform0[spawnLocation].position, 
                    orbSpawnTransform0[spawnLocation].rotation, orbsParent.transform);
            }

            if (spawnRow == 1)
            {
                spawnLocation = Random.Range(0, 11);
                Instantiate(orbPrefab, orbSpawnTransform1[spawnLocation].position,
                    orbSpawnTransform1[spawnLocation].rotation, orbsParent.transform);
            }

            if (spawnRow == 2)
            {
                spawnLocation = Random.Range(0, 11);
                Instantiate(orbPrefab, orbSpawnTransform2[spawnLocation].position, 
                    orbSpawnTransform2[spawnLocation].rotation, orbsParent.transform);
            }

            if (spawnRow == 3)
            {
                spawnLocation = Random.Range(0, 11);
                Instantiate(orbPrefab, orbSpawnTransform3[spawnLocation].position, 
                    orbSpawnTransform3[spawnLocation].rotation, orbsParent.transform);
            }

            timer = 0;
        }


    }
}
