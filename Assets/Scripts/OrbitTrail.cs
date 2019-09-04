using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTrail : MonoBehaviour
{

    public bool value;

    private void Update()
    {
        foreach (LineRenderer lr in GetComponentsInChildren<LineRenderer>())
        {
            Debug.Log("i'm here");
            lr.enabled = value;
        }
    }

    public void setValueOrbits()
    {
        value = !value ;
    }
}
