using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 rotateOrigin = new Vector3(0, 0, 0);
    [SerializeField][Range(0, 1)] private float minAngle = 0.5f;
    [SerializeField][Range(0, 1)] private float maxAngle = 0.5f;
    [SerializeField] private float rotateSpeed = 15f;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float minDistance = 1f;
    private void Update()
    {
        UpdateRotation();
        UpdateZoom();
    }
    private void Start()
    {
        transform.position = rotateOrigin - (Vector3.forward * maxDistance);
        //CheckRotation();
    }
    private void CheckRotation()
    {
        if (maxAngle < minAngle) { maxAngle = minAngle; }
        transform.LookAt(rotateOrigin, Vector3.up);
        float forwardYComponent = Mathf.Abs(transform.forward.y);
        while (forwardYComponent < minAngle)
        {
            //Needs to tilt down
            TiltDown();
            forwardYComponent = Mathf.Abs(transform.forward.y);

        }
        while (forwardYComponent > maxAngle)
        {
            //Needs to tilt up
            TiltUp();
            forwardYComponent = Mathf.Abs(transform.forward.y);
        }
    }

    private void UpdateZoom()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, rotateOrigin, Input.mouseScrollDelta.y * zoomSpeed);
        float distanceToOrigin = Vector3.Distance(rotateOrigin, newPos);
        if (distanceToOrigin <= maxDistance && distanceToOrigin >= minDistance)
        {
            //Makes sure the camera doesn't go too low or too high.
            transform.position = newPos;
        }
    }
    private void UpdateRotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            TiltDown();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            TiltUp();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 axis = this.transform.up;
            transform.RotateAround(rotateOrigin, axis, Time.deltaTime * -rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 axis = this.transform.up;
            transform.RotateAround(rotateOrigin, axis, Time.deltaTime * rotateSpeed);
        }
    }
    private void TiltUp()
    {
        Vector3 axis = this.transform.right;
        transform.RotateAround(rotateOrigin, axis, Time.deltaTime * -rotateSpeed);
        float forwardYComponent = Mathf.Abs(transform.forward.y);
        if (forwardYComponent < minAngle)
        {
            transform.RotateAround(rotateOrigin, axis, Time.deltaTime * rotateSpeed);
        }
    }
    private void TiltDown()
    {
        Vector3 axis = this.transform.right;
        transform.RotateAround(rotateOrigin, axis, Time.deltaTime * rotateSpeed);
        float forwardYComponent = Mathf.Abs(transform.forward.y);
        if (forwardYComponent > maxAngle)
        {
            transform.RotateAround(rotateOrigin, axis, Time.deltaTime * -rotateSpeed);
        }
    }
}