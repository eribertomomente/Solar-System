using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revolution : MonoBehaviour {

    public Slider speedSlider;
    public float radius;
    public float speed;
    
    void Update()
    {
        float updatedSpeed = speed * (1 + speedSlider.value) * 2;
        this.transform.localPosition = GetPosition(Time.time * updatedSpeed * Mathf.PI / 180.0f);
    }

    private Vector3 GetPosition(float angle)
    {
        var x = radius * Mathf.Sin(angle);
        var z = radius * Mathf.Cos(angle);
        return new Vector3(x, 0, z);
    }

    public Vector3 GetPositionInTime(float offset)
    {
        float updatedSpeed = speed * (1 + speedSlider.value) * 2;
        return GetPosition( (Time.time+offset) * updatedSpeed * Mathf.PI / 180.0f);

    }
}
