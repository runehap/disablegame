using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraspawner : MonoBehaviour
{
    [SerializeField]
    public GameObject extrahumanprfeb;
    public float spawnRateMax = 0.5f;
    public float spawnRateMin = 3f;
    public float spawnyMax = 1f;
    public float spawnyMin = -1f;

    private float spawnY;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        spawnY = Random.Range(spawnyMin, spawnyMax);
    }

    
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            Vector3 expos = new(transform.position.x, transform.position.y + spawnY, transform.position.z);
            timeAfterSpawn = 0f;

            GameObject extrahuman
                = Instantiate(extrahumanprfeb, expos, transform.rotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            spawnY = Random.Range(spawnyMin, spawnyMax);
        }
    }
}
