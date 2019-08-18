using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    
    public Transform planetTarget;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    


    public void SetPlanetTarget(Transform t)
    {
        Debug.Log("sono dentro setPlanet con: " + t.gameObject.name);
        planetTarget = t;
        AdjustOffset();
    }

    public void AdjustOffset()
    {
        offset.z = -2 * planetTarget.transform.localScale.x;
    }
    
        //// Get the left mouse button
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // Get mouse origin
        //    mouseOrigin = Input.mousePosition;
        //    isRotating = true;
        //}

        //// Get the middle mouse button
        //if (Input.GetMouseButtonDown(1))
        //{
        //    // Get mouse origin
        //    mouseOrigin = Input.mousePosition;
        //    isZooming = true;
        //}

        //// Disable movements on button release
        //if (!Input.GetMouseButton(0)) isRotating = false;
        //if (!Input.GetMouseButton(1)) isZooming = false;

        //// Rotate camera along X and Y axis
        //if (isRotating)
        //{
        //    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

        //    transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
        //    transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        //}

        //// Move the camera linearly along Z axis
        //if (isZooming)
        //{
        //    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

        //    Vector3 move = pos.y * zoomSpeed * transform.forward;
        //    transform.Translate(move, Space.World);
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    if (zoom)
        //    {
        //        zoom = false;
        //        return;
        //    }
        //    else
        //    {
        //        zoom = true;
        //        return;
        //    }
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    if (zoom)
        //    {
        //        zoom = false;
        //        target_tag = 0;
        //    }
        //}

        //if (target_tag == 0)
        //{
        //    target = GameObject.Find("Sun").transform;
        //    Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 1f, -5f));
        //    this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //}
        //else if (target_tag == 1)
        //{
        //    target = GameObject.Find("Mercury").transform;
        //    Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 0.6f, -3f));
        //    this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //}
        //else if (target_tag == 2)
        //{
        //    target = GameObject.Find("Venus").transform;
        //    Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 0.7f, -2.8f));
        //    this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //}
        //else if (target_tag == 3)
        //{
        //    target = GameObject.Find("EarthSystem").transform;
        //    Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 1f, -5f));
        //    this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //}
        //else if (target_tag == 4)
        //{
        //    target = GameObject.Find("Mars").transform;
        //    Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 0.7f, -4f));
        //    this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //}
        //else if (target_tag == 5)
        //{
        //    target = GameObject.Find("Moon").transform;
        //    Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 0.1f, -2f));
        //    this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime / 10);
        //}

    


    void LateUpdate()
    {
        if (planetTarget == null)
            return;
        Vector3 desiredPosition;
        Vector3 smoothedPosition;
        
        desiredPosition = planetTarget.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;

    }

}
