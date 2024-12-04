using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // 좌우 이동 속도
    public float jumpForce; // 점프 힘
    public LayerMask Ground;   // 바닥 레이어

    private Rigidbody2D rb;   // Rigidbody2D 컴포넌트
    private bool isGrounded;    // 바닥에 있는지 체크
    private GameManager gameManager;

    Animator Animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Rigidbody2D 컴포넌트 참조
        gameManager = FindObjectOfType<GameManager>(); // GameManager 컴포넌트 참조

        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();   // 좌우 이동 처리

        // 점프 처리: 바닥에 있을 때만 점프 가능
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // 플레이어 좌우 이동 처리
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)  // 좌우 입력이 있으면
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); // x 속도만 변경, y는 그대로 두기

            Animator.SetBool("Run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);  // 이동하지 않으면 x속도를 0으로 설정

            Animator.SetBool("Run", false);  // "Run"을 false로 설정하여 idle 애니메이션 실행
        }
    }

    // 점프 처리
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);    // y속도만 변경
        isGrounded = false; // 바닥에서 떨어졌음을 표시

        Animator.SetTrigger("jump_hero");
    }

    // 바닥과 충돌했을 때 바닥 상태 업데이트
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0) // 바닥 레이어와 충돌하면
        {
            isGrounded = true; // 바닥에 있다고 설정
        }
    }
}
