using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;     //?????????? ?? ??????? ?????????? ????????? ????????? ?????????

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))   //??????? ?? ?????? ?????, ???????? ? ?????????? Unity
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);   //????? OverlapSphere() ?????????? ?????? ????????? ????????
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;

                if (Vector3.Dot(transform.forward, direction) > 0.5f) //????????? ???????????? ?????? ??? ?????????? ?????????? ?????????
                {
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);  //????? SendMessage() ???????? ??????? ???????????
                }                                                                              //??????? ?????????? ?? ???????? ???????
            }                                                                               
        }
    }
}
