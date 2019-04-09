using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public float movementSpeed = 3f;
    float vertical;
    float horizontal;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        Vector3 direction = new Vector3(horizontal,0f,vertical);
        characterController.Move(transform.rotation * direction * movementSpeed * Time.deltaTime);
    }

    void GetInputs()
    {
        if (gameManager.GetInputStatus())
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }
    }
}