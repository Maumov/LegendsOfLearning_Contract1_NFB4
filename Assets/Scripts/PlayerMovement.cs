using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float rotationSpeed = 45f;
    float vertical;
    float horizontal;
    public bool inputStatus = true;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputStatus)
        {
            GetInputs();
            Vector3 direction = new Vector3(0f, -10f, vertical);
            transform.Rotate(0f,horizontal * rotationSpeed * Time.deltaTime,0f);
            characterController.Move(transform.rotation * direction * movementSpeed * Time.deltaTime);
        }
    }

    void GetInputs()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    public void SetInputStatus(bool status)
    {
        inputStatus = status;
    }
}