using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;   //смещение открытой двери относительно закрытой
    private bool _open;   //булева переменная для слежения за откртым состоянием двери

    public void Operate()
    {
        if (_open)   //открываем или закрываем дверь в зависимости от состояния двери
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        _open = !_open;
    }
    public void Activate()
    {
        if (!_open)           //открывает дверь приусловии что она закрыта
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
            _open = true;
        }
    }
    public void Deactivate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            _open = false;
        }
    }
}
