using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;     //расстояние на котором становится возможным активация устройств

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))   //реакция на кнопку ввода, заданную в настройках Unity
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);   //метод OverlapSphere() возвращает список ближайших обьектов
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;

                if (Vector3.Dot(transform.forward, direction) > 0.5f) //сообщение отправляется только при корректной ориентации персонажа
                {
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);  //метод SendMessage() пытается вызвать именованную
                }                                                                              //функцию независимо от целевого обьекта
            }                                                                               
        }
    }
}
