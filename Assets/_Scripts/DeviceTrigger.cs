using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] targets;   //список целевых обьектов, которые будут активировать триггер

    public bool requireKey;

    void OnTriggerEnter(Collider other)     //метод OnTriggerEnter() вызывается при попадании в зону триггера
    {
        if(requireKey && Managers.Inventory.equippedItem != "key")
        {
            return;
        }
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }
    void OnTriggerExit(Collider other)  //метод OnTriggerExit() вызывается при выходе обьекта из зоны триггера
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
