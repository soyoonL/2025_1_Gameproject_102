using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;  //체력을 선언한다.(정수)
    public float Timer = 1.0f;   // 최초 프레임이 업데이트 되기 전에 한번 실행된다.
    public int AttackPoint = 50;
    void Start()
    {
        Health += 100;          //이 스크립트가 실행 될 때 100을 더 올려준다.


    }

    // 게임 진행중인 매 프레임마다 호출된다.
    void Update()
    {
        CharacterHealthUp();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= AttackPoint;
        }
        CheckDeath();

    }
    public void CharacterHit(int Damage)
    {
        Health -= Damage;               //받은 공격력에 대한 체력을 감소시킨다
    }
    void CheckDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }


    }
    void CharacterHealthUp()
    {
        Timer -= Time.deltaTime;
         if (Health <= 0)
        {
            Timer = 1;
            Health += 10;
        }

           
    }
      
    

    
}
    
        
        
            
    

