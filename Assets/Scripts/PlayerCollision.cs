using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;

    // 구역 제한을 위한 변수
    public float minX, maxX;    // X축 제한

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();     // 충돌 시 게임 오버
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 위치를 제한된 범위 내로 조정
        Vector3 playerPosition = transform.position;

        // x좌표 제한
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);

        // 위치 업데이트
        transform.position = playerPosition;
    }
}
