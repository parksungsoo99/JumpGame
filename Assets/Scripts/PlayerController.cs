using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // �¿� �̵� �ӵ�
    public float jumpForce; // ���� ��
    public LayerMask Ground;   // �ٴ� ���̾�

    private Rigidbody2D rb;   // Rigidbody2D ������Ʈ
    private bool isGrounded;    // �ٴڿ� �ִ��� üũ
    private GameManager gameManager;

    Animator Animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Rigidbody2D ������Ʈ ����
        gameManager = FindObjectOfType<GameManager>(); // GameManager ������Ʈ ����

        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();   // �¿� �̵� ó��

        // ���� ó��: �ٴڿ� ���� ���� ���� ����
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // �÷��̾� �¿� �̵� ó��
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)  // �¿� �Է��� ������
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); // x �ӵ��� ����, y�� �״�� �α�

            Animator.SetBool("Run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);  // �̵����� ������ x�ӵ��� 0���� ����

            Animator.SetBool("Run", false);  // "Run"�� false�� �����Ͽ� idle �ִϸ��̼� ����
        }
    }

    // ���� ó��
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);    // y�ӵ��� ����
        isGrounded = false; // �ٴڿ��� ���������� ǥ��

        Animator.SetTrigger("jump_hero");
    }

    // �ٴڰ� �浹���� �� �ٴ� ���� ������Ʈ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0) // �ٴ� ���̾�� �浹�ϸ�
        {
            isGrounded = true; // �ٴڿ� �ִٰ� ����
        }
    }
}
