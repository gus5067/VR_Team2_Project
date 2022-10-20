using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private Vector3 posBox;

    private Vector3 moveDir;

    private Vector3 localPos;

    private Vector3 prevPos;
    [SerializeField]
    private bool isRiding;
    // 로컬포지션 z값은 2.5~ -3까지, y값은 3.2고정, 1~-1
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerPosLimit();
        if(isRiding)
        {
            PlayerMove();
        }


    }
    
    private void PlayerMove()
    {
        // 위, 아래 움직임 셋팅. 
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
        moveDir = transform.TransformDirection(moveDir);


        // 캐릭터 움직임.
        controller.Move(moveDir * 5 * Time.deltaTime);
    }

    private void PlayerPosLimit()
    {
        localPos = new Vector3(Mathf.Clamp(transform.localPosition.x, -1f, 1f),transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, -3f, 2.5f));

        transform.localPosition = localPos;

        Debug.Log(transform.localPosition.x + " && " + transform.localPosition.z);

        if(transform.localPosition.x >= 1f || transform.localPosition.x <= -1f)
        {
            isRiding = false;
            transform.localPosition = prevPos;
        }
        else if(transform.localPosition.z >= 2.5f || transform.localPosition.z <= -3f)
        {
            isRiding = false;
            transform.localPosition = prevPos;
        }
        else
        {
            isRiding = true;
            prevPos = transform.localPosition;
        }
     

    }
}
