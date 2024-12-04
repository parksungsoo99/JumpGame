using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed; // 적 이동 속도
    float screenLimit; // 화면 왼쪽 끝을 기준으로 삭제할 위치
    GameManager gameManager;

    void Start()
    {
        // 화면 왼쪽 끝을 기준으로 삭제할 위치를 설정 (카메라 뷰를 기준으로)
        screenLimit = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - 1f; // 카메라의 왼쪽 끝 위치에서 약간 더 왼쪽으로 설정
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // 적이 왼쪽으로 이동하도록 설정
        // x축 -1 방향으로 이동
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 화면 밖으로 나가면 삭제
        if (transform.position.x < screenLimit)
        {
            Destroy(gameObject); // 게임 오브젝트 삭제
        }
    }

    // 충돌 시 플레이어와 충돌하면 게임 오버
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver(); // GameManager의 GameOver 메서드 호출
        }
    }
}
