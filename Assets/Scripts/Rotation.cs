using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour {
    public float speed = 120.0f;
    public Slider speedSlider;

    void Update ()
    {
        float updatedSpeed = speed * (1 + speedSlider.value) * 2;
        this.transform.Rotate(Vector3.up, Time.deltaTime * updatedSpeed);
    }
}
