using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;

    // ���� ������ ���� ����
    public float minX, maxX;    // X�� ����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();     // �浹 �� ���� ����
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾��� ��ġ�� ���ѵ� ���� ���� ����
        Vector3 playerPosition = transform.position;

        // x��ǥ ����
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);

        // ��ġ ������Ʈ
        transform.position = playerPosition;
    }
}
