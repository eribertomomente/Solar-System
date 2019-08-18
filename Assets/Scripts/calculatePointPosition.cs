using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculatePointPosition : MonoBehaviour
{

    public Transform[] points;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        int NUMBER_CTRL_POINTS = points.Length - 1;
        float alpha = 2*Mathf.PI / (2* NUMBER_CTRL_POINTS);
        float R = radius / Mathf.Cos(alpha);
        points[0].localPosition = new Vector3(radius * Mathf.Sin(0), -radius * Mathf.Cos(0),0);
        for(int i = 0; i < NUMBER_CTRL_POINTS; i++)
        {
            float x = R * Mathf.Sin((2 * i + 1) * alpha);
            float y = -R * Mathf.Cos((2 * i + 1) * alpha);
            Debug.Log("x: " + x + "\ny: " + y);
            points[i+1].localPosition = new Vector3(x, y, 0);
        }
    }
    
}
