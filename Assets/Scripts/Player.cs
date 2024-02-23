using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float motionSpeed = 7.0f;
    [SerializeField] private float rotationalSpeed = 10f;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = new(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        Vector3 moveDirection = new(inputVector.x, 0, inputVector.y);
        transform.position += motionSpeed * Time.deltaTime * moveDirection;

        isWalking = moveDirection != Vector3.zero;

        // Make the player look forward in the moving direction
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationalSpeed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
