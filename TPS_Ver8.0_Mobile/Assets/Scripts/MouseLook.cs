using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0.01f;
    public Transform playerBody;
    float xRotation = 0f;

    //터치를 입력받아 Player를 컨트롤합니다.
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector2 position = touch.position;
                //터치를 인식할 수 있는 범위를 지정합니다.
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && position.x > 600 && position.x < 1900)
                {
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