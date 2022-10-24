using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusHp : MonoBehaviour,IDamageable
{
    [SerializeField]
    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (value <= 0)
            {

                Debug.Log("���� ����");
                GameManager.instance.busController.Speed = 0;
            }
            else
            {
                hp = value;
                Debug.Log("���� ü�� : " + hp);
            }

        }
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;
    }
}
