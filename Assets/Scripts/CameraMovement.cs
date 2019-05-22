using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Transform YRotationtransform;
    private static bool inputStatus = true;
    private static PlayerMovement movement;

    public float minX = -60f, maxX = 60f;

    float vertical;
    float horizontal;

  
    // Start is called before the first frame update
    void Start()
    {
        movement = target.GetComponent<PlayerMovement>();

        transform.SetParent(target);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputStatus)
        {
            //GetInputs();

            target.RotateAround(target.position, Vector3.up, horizontal);
            YRotationtransform.RotateAround(YRotationtransform.position, YRotationtransform.right, vertical);
        }
    }
    void GetInputs() {
        vertical = -Input.GetAxis("Mouse Y");
        horizontal = Input.GetAxis("Mouse X");
        float angle = -Vector3.SignedAngle(transform.forward, YRotationtransform.forward, target.right);

        if (vertical < 0f && angle > maxX)
        {
            vertical = 0f;
        }
        if (vertical > 0f && angle < minX)
        {
            vertical = 0f;
        }
    }

    public void SetInputStatus(bool status)
    {
        inputStatus = status;

        if(movement != null)
        {
            movement.SetInputStatus(status);
        }
    }

    public static void StaticSetInputs(bool status)
    {
        inputStatus = status;
        if (movement != null)
        {
            movement.SetInputStatus(status);
        }
    }
}