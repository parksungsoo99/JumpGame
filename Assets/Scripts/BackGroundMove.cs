using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float scrollSpeed; // 배경의 이동속도
    public float backGroundWidth; // 배경의 너비
    public GameObject backGround1;  // 첫 번째 배경
    public GameObject backGround2;  // 두 번째 배경
    // public GameObject backGround3;  // 세 번째 배경

    Vector3 startPos1;  // backGround1의 시작 위치
    Vector3 startPos2;  // backGround2의 시작 위치
    // Vector3 startPos3;  // backGround3의 시작 위치
    void Start()
    {
        // 각각 배경의 시작 위치 저장
        startPos1 = backGround1.transform.position;
        startPos2 = backGround2.transform.position;
        // startPos3 = backGround3.transform.position;

        // 배경의 너비를 계산 (세 배경은 같은 크기여야 함)
        backGroundWidth = backGround1.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // 두 배경을 왼쪽으로 이동
        MoveBackground(backGround1);
        MoveBackground(backGround2);
        // MoveBackground(backGround3);
    }

    // 배경을 이동시키고, 화면 밖으로 나가면 반대편으로 위치 이동
    void MoveBackground(GameObject backGround)
    {
        backGround.transform.position = new Vector3(backGround.transform.position.x - scrollSpeed * Time.deltaTime, backGround.transform.position.y, 0);

        // 배경이 화면 밖으로 나가면 다시 반대편으로 위치
        if (backGround.transform.position.x <= -backGroundWidth)
        {
            // 반대편으로 이동 (다시 처음 위치로 설정)
            backGround.transform.position = new Vector3(backGround.transform.position.x + 2 * backGroundWidth, backGround.transform.transform.position.y, 0);
        }
    }
}
