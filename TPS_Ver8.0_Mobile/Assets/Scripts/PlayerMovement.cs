using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    public LayerMask groundMask;
    // Update is called once per frame
    void Update()
    {
        // 땅에 붙어있는지 체크
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            // 붙어있다면 y방향으로 속도 0에 수렴. (0f 이어도 되지만, 동작의 부드러움을 위해 -2f)
            velocity.y = -2f;
        }

        // 중력설정
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void Move(Vector2 inputDirection)
    {
        Vector2 moveInput = inputDirection;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        // 상하좌우 애니메이션 파라미터 설정
        anim.SetFloat("Speed", moveInput.y);
        anim.SetFloat("Horizontal", moveInput.x);
        controller.Move(move * speed * Time.deltaTime);
    }
}
