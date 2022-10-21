using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Player : MonoBehaviour
{
   // private CharacterController controller;

    private Vector3 moveDir;

    private Vector3 localPos;

    private Vector3 prevPos;

    [SerializeField]
    private LaserPoint laser;

    // ���������� z���� 2.5~ -3����, y���� 3.2����, 1~-1
    private void Awake()
    {
        //controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            laser.gameObject.SetActive(true);
        }
        Teleport();
        //transform.localPosition = new Vector3(0, 4.4f, 0);
        //PlayerPosLimit();
        //if(isRiding)
        //{
        //    PlayerMove();
        //}



    }
    //��Ʈ�ѷ��� ���� �̵�
    //private void PlayerMove()
    //{
    //    // ��, �Ʒ� ������ ����. 
    //    moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    //    // ���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ�Ѵ�.
    //    moveDir = transform.TransformDirection(moveDir);


    //    // ĳ���� ������.
    //    controller.Move(((moveDir * 5) + Vector3.up * Physics.gravity.y) * Time.deltaTime);
    //} 
    //���� �̵� ��ġ ����
    //private void PlayerPosLimit()
    //{
    //    localPos = new Vector3(Mathf.Clamp(transform.localPosition.x, -1f, 1f), transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, -3f, 2.5f));

    //    transform.localPosition = localPos;

    //    Debug.Log(transform.localPosition.x + " && " + transform.localPosition.z);

    //    if (transform.localPosition.x >= 1f || transform.localPosition.x <= -1f)
    //    {
    //        isRiding = false;
    //        transform.localPosition = prevPos;
    //    }
    //    else if (transform.localPosition.z >= 2.5f || transform.localPosition.z <= -3f)
    //    {
    //        isRiding = false;
    //        transform.localPosition = prevPos;
    //    }
    //    else
    //    {
    //        isRiding = true;
    //        prevPos = transform.localPosition;
    //    }

     

    //}

    //�ڷ���Ʈ
    private void Teleport()
    {
        if(Input.GetMouseButtonDown(0) && laser.gameObject.activeSelf)
        {
            TeleportSpace space = laser.laserTarget.transform.GetComponent<TeleportSpace>();
            if (space != null)
            {
                transform.localPosition = space.posOffset;
                transform.localRotation = Quaternion.Euler(space.rotOffset);
            }
        }
    }
}
