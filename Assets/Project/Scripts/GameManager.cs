using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //���� �̱������� ������ ���� �Ŀ� �ʿ伺 ������ �̱������� ����

    private void Awake()
    {
        instance = this;
    }

    public BusSpeedController busController;

    public BusHp busHp;


}
