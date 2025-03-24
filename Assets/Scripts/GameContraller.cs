using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContraller : MonoBehaviour
{
    public float Timer = 1.0f;   // 최초 프레임이 업데이트 되기 전에 한번 실행된다.
    public GameObject EnemyObject;
    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 1;
            GameObject temp = Instantiate(EnemyObject);
            temp.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
           
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log($"hit:{hit.collider.name}");
                    hit.collider.gameObject.GetComponent<Enemy>().CharacterHit(30);
                }
            }
        }

    }
}
