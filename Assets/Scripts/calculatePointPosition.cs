using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculatePointPosition : MonoBehaviour
{
    public GameObject originalPoint;
    public const int NUMBER_CTRL_POINTS =5;
    public float radius;

    // Start is called before the first frame update
    void Awake()
    {
        float alpha = 2*Mathf.PI / (2* NUMBER_CTRL_POINTS);
        float R = radius / Mathf.Cos(alpha);
        
        for(int i = 0; i < NUMBER_CTRL_POINTS; i++)
        {
            float interpX = radius * Mathf.Sin(2 * i * alpha);
            float interpZ = -radius * Mathf.Cos(2 * i * alpha);
            GameObject goInterp = Instantiate(originalPoint, this.transform);
            goInterp.name = "p" + 1;
            goInterp.transform.localPosition = new Vector3(interpX, 0, interpZ);

            float ctrlX = R * Mathf.Sin((2 * i + 1) * alpha);
            float ctrlZ = -R * Mathf.Cos((2 * i + 1) * alpha);
            GameObject goCtrl = Instantiate(originalPoint, this.transform);
            goCtrl.name = "c" + i;
            goCtrl.transform.localPosition = new Vector3(ctrlX, 0, ctrlZ);

        }
    }

    
    
}
