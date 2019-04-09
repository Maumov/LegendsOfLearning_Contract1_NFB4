using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Transform target;
    public Transform YRotationtransform;

    public float minX = -60f, maxX = 60f;

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

        target.RotateAround(target.position, Vector3.up, horizontal);
        YRotationtransform.RotateAround(YRotationtransform.position, YRotationtransform.right, vertical);
    }
    void GetInputs() {
        if (gameManager.GetInputStatus())
        {
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
    }
}
