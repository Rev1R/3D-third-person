using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;

    private void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;         //сохраняем начальное смещение между камерой и целью
    }
    private void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if(horInput != 0)
        {
            _rotY += horInput * rotSpeed;                            //медленный поворот камеры с помощью кнопок
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;        //быстрый поворот камеры с помощью мыши
        }
        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);   //где бы ни находилась камера, она всегда смотрит на цель
    }
}
