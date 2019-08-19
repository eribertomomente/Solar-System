using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculatePointPosition : MonoBehaviour
{

    public GameObject interpolationPointsContainer;
    public GameObject controlPointsContainer;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] interpolationPoints = getChildrenPoints(interpolationPointsContainer);
        Transform[] controlPoints = getChildrenPoints(controlPointsContainer);

        int NUMBER_CTRL_POINTS = controlPoints.Length;
        //Debug.Log(NUMBER_CTRL_POINTS);
        float alpha = 2*Mathf.PI / (2* NUMBER_CTRL_POINTS);
        float R = radius / Mathf.Cos(alpha);
        
        for(int i = 0; i < NUMBER_CTRL_POINTS; i++)
        {
            float ctrlX = R * Mathf.Sin((2 * i + 1) * alpha);
            float ctrlY = -R * Mathf.Cos((2 * i + 1) * alpha);
            controlPoints[i].localPosition = new Vector3(ctrlX, ctrlY, 0);

            float interpX = radius * Mathf.Sin(2*i*alpha);
            float interpY = -radius * Mathf.Cos(2 * i * alpha);
            Debug.Log(interpX + " " + interpY);
            interpolationPoints[i].localPosition = new Vector3(interpX, interpY, 0);
        }
    }


    private Transform[] getChildrenPoints(GameObject container)
    {
        int pointsNumber = container.transform.childCount;
        Transform[] resultPoints = new Transform[pointsNumber];

        for(int i = 0; i < pointsNumber; i++)
        {
            resultPoints[i] = container.transform.GetChild(i);
        }
        return resultPoints;
    }
    
}
