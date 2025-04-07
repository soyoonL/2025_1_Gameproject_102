using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MissilePrefabs;

    [Header("스폰 타이밍 결정")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;
    [Header("동전 스폰 확률 설정")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;

    public float timer = 0.0f;
    public float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextSpawnTime)
        {
            SpawnObject();
            timer = 0.0f;
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
       
        nextSpawnTime=Random.Range(minSpawnInterval,maxSpawnInterval);   
    }

    void SpawnObject()
    {
        Transform spawnTransform = transform;

        //확률에 따라 동전 또는 미사일 생성
        int randomValue = Random.Range(0,100);
        if(randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position,spawnTransform.rotation);
        }
        else
        {
            Instantiate(MissilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
            
    }
}
