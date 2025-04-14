using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public CubeGenerator[] generatorCubes=new CubeGenerator[5];     //Ŭ���� �迭

    public float timer = 0.0f;
    public float interval = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            RandomizeCubeActivation();
            timer = 0.0f;
        }
    }

    public void RandomizeCubeActivation()
    {
        for (int i = 0; i < generatorCubes.Length; i++)
        {
            int randomNum = Random.Range(0, 2);
            if(randomNum == 1)
            {
                generatorCubes[i].Gencube();
            }
        }
    }
}
