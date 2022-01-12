using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : MonoBehaviour
{
  public void Operate()      //обьявления метода с таким же именем как в сценарии для двери
    {
        Color random = new Color(Random.Range(0f, 1f), Random.Range(0f,1f),Random.Range(0f,1f));
        GetComponent<Renderer>().material.color = random;
    }
}
