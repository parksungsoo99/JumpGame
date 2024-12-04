using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float scrollSpeed; // ����� �̵��ӵ�
    public float backGroundWidth; // ����� �ʺ�
    public GameObject backGround1;  // ù ��° ���
    public GameObject backGround2;  // �� ��° ���
    // public GameObject backGround3;  // �� ��° ���

    Vector3 startPos1;  // backGround1�� ���� ��ġ
    Vector3 startPos2;  // backGround2�� ���� ��ġ
    // Vector3 startPos3;  // backGround3�� ���� ��ġ
    void Start()
    {
        // ���� ����� ���� ��ġ ����
        startPos1 = backGround1.transform.position;
        startPos2 = backGround2.transform.position;
        // startPos3 = backGround3.transform.position;

        // ����� �ʺ� ��� (�� ����� ���� ũ�⿩�� ��)
        backGroundWidth = backGround1.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // �� ����� �������� �̵�
        MoveBackground(backGround1);
        MoveBackground(backGround2);
        // MoveBackground(backGround3);
    }

    // ����� �̵���Ű��, ȭ�� ������ ������ �ݴ������� ��ġ �̵�
    void MoveBackground(GameObject backGround)
    {
        backGround.transform.position = new Vector3(backGround.transform.position.x - scrollSpeed * Time.deltaTime, backGround.transform.position.y, 0);

        // ����� ȭ�� ������ ������ �ٽ� �ݴ������� ��ġ
        if (backGround.transform.position.x <= -backGroundWidth)
        {
            // �ݴ������� �̵� (�ٽ� ó�� ��ġ�� ����)
            backGround.transform.position = new Vector3(backGround.transform.position.x + 2 * backGroundWidth, backGround.transform.transform.position.y, 0);
        }
    }
}
