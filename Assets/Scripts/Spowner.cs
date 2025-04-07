using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MissilePrefabs;

    [Header("���� Ÿ�̹� ����")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;
    [Header("���� ���� Ȯ�� ����")]
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

        //Ȯ���� ���� ���� �Ǵ� �̻��� ����
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
