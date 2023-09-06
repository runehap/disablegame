using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraspawner : MonoBehaviour
{
    [SerializeField]
    public GameObject extrahumanprfeb;
    public float spawnRateMax = 0.5f;
    public float spawnRateMin = 3f;

    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject extrahuman
                = Instantiate(extrahumanprfeb, transform.position, transform.rotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
