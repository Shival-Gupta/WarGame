using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    [SerializeField] public float mouseSensitivity = 100f;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hides Cursor
    }
        void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Confined; // Shows Cursor
            else if(Cursor.lockState == CursorLockMode.Confined)
                Cursor.lockState = CursorLockMode.Locked; // Hides Cursor
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,  90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Up and Down
        playerBody.Rotate(Vector3.up * mouseX); // Left and Right
    }
}
