using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BezierCalculator : MonoBehaviour
{

    public LineRenderer curve;

    [Range(10, 200)]
    public int precision = 100;
    private Vector3[] positions;
    
    private Transform[] controlPoints;
    public float weight;



    // Start is called before the first frame update
    void Start()
    {
        controlPoints = getChildrenPoints(gameObject);

        weight = (float)Math.Cos(2 * Mathf.PI / controlPoints.Length);

        curve.positionCount = precision * controlPoints.Length / 2;
        //positions = new Vector3[precision * controlPoints.Length / 2];

        DrawRationalCircle();
    }

    // Update is called once per frame
    void Update()
    {
        DrawRationalCircle();
    }

    private void DrawRationalCircle()
    {
        for (int i = 0; i < controlPoints.Length/2; i++)
        {

            Transform[] triple = new Transform[3];
            for(int j = 0; j<3; j++)
            {
                triple[j] = controlPoints[(i*2 + j)%controlPoints.Length];
            }
            DrawRationalCurve(triple, i);
        }
    }


    private void DrawRationalCurve(Transform[] points, int index)
    {
        for (int i = 0; i < precision; i++)
        {
            float t = i / (float)precision;
            curve.SetPosition(i + (index*precision), CalculateRationalBezierPoint(t, points, index));
        }
    }

    private Vector3 CalculateRationalBezierPoint(float t, Transform[] points, int index)
    {
        int n = points.Length;
        Vector3 numerator = Vector3.zero;
        float denominator = 0;
        for (int i=0; i<n; i++)
        {
            // calcolo (n su i)
            int n_i = CalculateCoeffBin(n, i);
            numerator += n_i * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i) * points[ i ].localPosition * weight;
            denominator += n_i * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i)* weight;

        }
        return numerator / denominator;
    }

    public int CalculateCoeffBin(int n, int i)
    {
        int result = 1;
        for (int k = 1; k <= i; k++)
        {
            result *= n - (i - k);
            result /= k;
        }
        return result;
    }

    private Transform[] getChildrenPoints(GameObject container)
    {
        int pointsNumber = container.transform.childCount;
        Transform[] resultPoints = new Transform[pointsNumber];

        for (int i = 0; i < pointsNumber; i++)
        {
            resultPoints[i] = container.transform.GetChild(i);
        }
        return resultPoints;
    }
    
}
