using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3Object playerPosition;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject playerCamera;
    Vector3 horizontalMovement, verticalMovement;

    private void Update()
    {
      playerPosition.value = transform.position;
      MovePlayer();
    }

    private void MovePlayer()
    {
      horizontalMovement = Input.GetAxisRaw("Horizontal") * playerCamera.transform.right;
      verticalMovement = Input.GetAxisRaw("Vertical") * playerCamera.transform.forward;
      Vector3 playerVel = (horizontalMovement + verticalMovement).normalized * movementSpeed;
      rb.velocity = playerVel;

    }
}
