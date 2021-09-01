using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0.01f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        //anim = GetComponent<Animator>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector2 position = touch.position;
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && position.x > 600 && position.x < 1900)
                {
                    //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                    //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                    float mouseX = Input.GetTouch(i).deltaPosition.x * mouseSensitivity * Time.deltaTime;
                    float mouseY = Input.GetTouch(i).deltaPosition.y * mouseSensitivity * Time.deltaTime;

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                    playerBody.Rotate(Vector3.up * mouseX);
                }
            }

        }
    }
}