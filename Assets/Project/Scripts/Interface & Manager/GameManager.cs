using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //아직 싱글톤으로 만들지 않음 후에 필요성 느끼면 싱글톤으로 변경

    private void Awake()
    {
        instance = this;
    }

    public BusSpeedController busController;

    public BusHp busHp;


}
