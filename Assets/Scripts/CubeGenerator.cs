using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int totalCubes = 10;
    public float cubeSpacing = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Gencube();
    }

    // Update is called once per frame
    public void Gencube()
    {
       Vector3 myPosition=transform.position;
        GameObject firstCube=Instantiate(cubePrefab, myPosition, Quaternion.identity);//첫번째 큐브 생성

        for (int i = 1;i< totalCubes; i++)
        {
            //내 위치에서 z축으로 일정간격 떨어진 위치에 생성
            Vector3 position=new Vector3(myPosition.x, myPosition.y, myPosition.z+(i*cubeSpacing));
            Instantiate(cubePrefab,position,Quaternion.identity);//큐브 생성
        }
    }
}
