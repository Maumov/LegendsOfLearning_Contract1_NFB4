using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    float vertical;
    float horizontal;
    private bool inputStatus = true;

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
            Vector3 direction = new Vector3(horizontal, -10f, vertical);

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