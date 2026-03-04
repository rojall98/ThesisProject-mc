using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private int mouseSensitivity = 100;
    public Transform playerCamera;
    float xRotation, yRotation;
    float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        Mathf.Clamp(xRotation, -30f, 40f);
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
