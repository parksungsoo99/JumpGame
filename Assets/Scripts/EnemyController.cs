using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;  // �� ������
    public float spawnIntervalMin ; // ��ֹ� ���� ���� �ּڰ�
    public float spawnIntervalMax; // ��ֹ� ���� ���� �ִ�
    public float spawnMinX; // ��ֹ��� ������ x ��ǥ �ּҰ�
    public float spawnMaxX; // ��ֹ��� ������ x ��ǥ �ִ�
    // public float spawnPosMinY; // ��ֹ��� ������ y��ǥ �ּڰ�
    // public float spawnPosMaxY; // ��ֹ��� ������ y��ǥ �ִ�

    // spawnPosition�� ���� ������ ����
    Vector3 spawnPosition;

    void Start()
    {
        // ���� �������� ��ֹ� ����
        // InvokeRepeating("SpawnEnemiesWithDelay", 0f, spawnInterval);

        // �ڷ�ƾ ���� ����
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �ڷ�ƾ�� ����Ͽ� ���� ���� �ð� �������� ���� �� ����
    IEnumerator SpawnEnemiesWithDelay()
    {
        // ���� ���� ���(�ݺ������� ���� ����)
        while (true)
        {
            // ������ ���� ���� ���� ����(1~5���� �� ����)
            int randomEnemyCount = Random.Range(1, 6);

            // 0���� 10 ������ ���� �� ����
            // float randomValue = Random.Range(0f, 10f);

            /*
            
            // ������ ��ġ ���� (Ȯ���� ���� ��ġ ����)
            float randomY = 0f;

            // Ȯ���� ���� Y��ġ ����
            if (randomValue < 5f)   // 50% Ȯ���� �Ʒ��� �� ����
            {
                randomY = Random.Range(spawnPosMinY, spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.3f); // �Ʒ�
                Debug.Log("�Ʒ�");
            }
            else if (randomValue < 8f)  // 40% Ȯ���� �߰��� �� ����
            {
                randomY = Random.Range(spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.4f, spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.6f); // ���
                Debug.Log("�߰�");
            }
            else // 20% Ȯ���� ��
            {
                randomY = Random.Range(spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.7f, spawnPosMaxY);
                Debug.Log("��");
            }

            */

            // X ���� ������ ������ ��ġ ���� (�����ʿ��� ����)
            float randomX = Random.Range(spawnMinX, spawnMaxX); // spawnMinX = x���� �ּڰ�, spawnMaxX = x���� �ִ�
            spawnPosition = new Vector3(randomX, -2.5f, 0);  // spawnPosition ������Ʈ


            // ������ ������ŭ �� ����
            for (int i = 0; i < randomEnemyCount; i++)
            {
                // ù ��° �� ����
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // �� ������ ������ �ð� ������ �ΰ� ����
                float randomWaitTime = Random.Range(0.5f, 2f);
                yield return new WaitForSeconds(randomWaitTime);
            }

            // ���� �ð� �������� �ٽ� �ݺ��ǵ���
            float randomSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(randomSpawnInterval); // ���� �������� ���� �ð� ���
        }
    }
}