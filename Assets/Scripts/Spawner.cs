using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    private List<GameObject> objectPool;
    private int poolSize = 5;
    private float timer = 0;
    private float nextSpawnTime = 0;

    private Vector3 spawnerPosition;
    private Quaternion spawnerRotation;

    void Start()
    {

        spawnerPosition = transform.position;
        spawnerRotation = transform.rotation;

        objectPool = new List<GameObject>();
        GameObject go;
        for (int i = 0; i < poolSize; i++)
        {
            go = Instantiate(objectToSpawn, spawnerPosition, spawnerRotation);
            go.SetActive(false);
            objectPool.Add(go);
        }
        nextSpawnTime = Random.Range(2.0f, 5.0f);
    }

    void Update()
    { 
        if (timer >= nextSpawnTime)
        {
            GameObject go = GetPooledObject();
            if (go != null)
            {
                go.transform.position = spawnerPosition;
                go.transform.rotation = spawnerRotation;
                go.SetActive(true);
            }
            nextSpawnTime = Random.Range(2.0f, 5.0f);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }
        return null;
    }
}
