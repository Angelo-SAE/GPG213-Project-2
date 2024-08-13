using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera, pCamera;
    [SerializeField] private float sensitivityX, sensitivityY;
    private float horizontalInput, verticalInput;
    private float angle;

    private void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
      GetMouseInput();
      RotatePlayer();
    }

    private void GetMouseInput()
    {
      horizontalInput = Input.GetAxis("Mouse X") * sensitivityX * 100 * Time.deltaTime;
      verticalInput = Input.GetAxis("Mouse Y") * sensitivityY * 100 * Time.deltaTime;
    }

    private void RotatePlayer()
    {
      angle -= verticalInput;
      angle = Mathf.Clamp(angle, -80, 75);
      playerCamera.transform.localRotation = Quaternion.Euler(angle, pCamera.transform.eulerAngles.y + horizontalInput, 0);
    }
}
