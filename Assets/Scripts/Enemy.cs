using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;  //ü���� �����Ѵ�.(����)
    public float Timer = 1.0f;   // ���� �������� ������Ʈ �Ǳ� ���� �ѹ� ����ȴ�.
    public int AttackPoint = 50;
    void Start()
    {
        Health += 100;          //�� ��ũ��Ʈ�� ���� �� �� 100�� �� �÷��ش�.


    }

    // ���� �������� �� �����Ӹ��� ȣ��ȴ�.
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
        Health -= Damage;               //���� ���ݷ¿� ���� ü���� ���ҽ�Ų��
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
    
        
        
            
    

