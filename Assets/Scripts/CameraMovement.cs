using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public Transform YRotationtransform;

    float vertical;
    float horizontal;

  
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(target);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        transform.RotateAround(transform.position, Vector3.up, horizontal);
        YRotationtransform.RotateAround(YRotationtransform.position, YRotationtransform.right, vertical);
    }
    void GetInputs() {
        vertical = Input.GetAxis("Mouse Y");
        horizontal = Input.GetAxis("Mouse X");
    }
}
