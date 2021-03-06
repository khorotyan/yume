﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public GameObject camObject;

    private float perspectiveZoomSpeed = 0.05f;        // The rate of change of the field of view in perspective mode.
    private float orthoZoomSpeed = 0.05f;        // The rate of change of the orthographic size in orthographic mode.

    float cameraDistanceMax = 7f;
    float cameraDistanceMin = 3f;
    float scrollSpeed = 4f;

    void Update()
    {
        // Zoom with scrollwheel
        float cameraDistance = camObject.GetComponent<Camera>().orthographicSize;
        cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        camObject.GetComponent<Camera>().orthographicSize = cameraDistance;

        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (camObject.GetComponent<Camera>().orthographic == true)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                camObject.GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                camObject.GetComponent<Camera>().orthographicSize = Mathf.Max(camObject.GetComponent<Camera>().orthographicSize, cameraDistanceMin);

                camObject.GetComponent<Camera>().orthographicSize = Mathf.Min(camObject.GetComponent<Camera>().orthographicSize, cameraDistanceMax);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                camObject.GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                camObject.GetComponent<Camera>().fieldOfView = Mathf.Clamp(camObject.GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}