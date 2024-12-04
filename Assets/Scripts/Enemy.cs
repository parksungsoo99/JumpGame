using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed; // �� �̵� �ӵ�
    float screenLimit; // ȭ�� ���� ���� �������� ������ ��ġ
    GameManager gameManager;

    void Start()
    {
        // ȭ�� ���� ���� �������� ������ ��ġ�� ���� (ī�޶� �並 ��������)
        screenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - 1f; // ī�޶��� ���� �� ��ġ���� �ణ �� �������� ����
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // ���� �������� �̵��ϵ��� ����
        // x�� -1 �������� �̵�
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // ȭ�� ������ ������ ����
        if (transform.position.x < screenLimit)
        {
            Destroy(gameObject); // ���� ������Ʈ ����
        }
    }

    // �浹 �� �÷��̾�� �浹�ϸ� ���� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver(); // GameManager�� GameOver �޼��� ȣ��
        }
    }
}
