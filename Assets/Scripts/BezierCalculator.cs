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
 
    public Transform[] points;
    public float[] weights;



    // Start is called before the first frame update
    void Start()
    {
        curve.positionCount = precision;
        positions = new Vector3[precision];
        
        DrawRationalCurve();
    }

    // Update is called once per frame
    void Update()
    {
        DrawRationalCurve();
    }

    //private void DrawQuadraticCurve()
    //{
    //    for (int i = 0; i < numPoints; i++)
    //    {
    //        float t = i /(float) numPoints;
    //        positions[i] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);
    //    }
    //    positions[numPoints] = CalculateQuadraticBezierPoint(1, point0.position, point1.position, point2.position);
    //    curve.SetPositions(positions);
    //}

    private void DrawRationalCurve()
    {
        for (int i = 0; i < precision; i++)
        {
            float t = i / (float)precision;
            positions[i] = CalculateRationalBezierPoint(t, points);
        }
        curve.SetPositions(positions);
    }

    //private Vector3 CalculateQuadraticBezierPoint( float t, Vector3 p0, Vector3 p1, Vector3 p2)
    //{
    //    // formula: (1-t)^2P0 + 2(1-t)tP1 + t^2P2
    //    //            u             u       tt
    //    //            uu p0  +    2ut p1  +  tt P2
    //    float u = 1 - t;
    //    float tt = t * t;
    //    float uu = u * u;
    //    Vector3 p = uu * p0 + 2 * u * t * p1 + tt * p2;
    //    return p;
    //}


    private Vector3 CalculateRationalBezierPoint(float t, Transform[] points)
    {
        int n = points.Length;
        Vector3 numerator = Vector3.zero;
        float denominator = 0;
        for (int i=0; i<n; i++)
        {
            // calcolo (n su i)
            int n_i = CalculateCoeffBin(n, i);
            numerator += n_i * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i) * points[ i ].localPosition * weights[i];
            denominator += n_i * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i)* weights[i];

        }
        //Debug.Log("Num: " + numerator + "\nDen: " + denominator);
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
}
