using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;  // 적 프리팹
    public float spawnIntervalMin ; // 장애물 생성 간격 최솟값
    public float spawnIntervalMax; // 장애물 생성 간격 최댓값
    public float spawnMinX; // 장애물이 생성될 x 좌표 최소값
    public float spawnMaxX; // 장애물이 생성될 x 좌표 최댓값
    // public float spawnPosMinY; // 장애물이 생성될 y좌표 최솟값
    // public float spawnPosMaxY; // 장애물이 생성될 y좌표 최댓값

    // spawnPosition을 전역 변수로 선언
    Vector3 spawnPosition;

    void Start()
    {
        // 일정 간격으로 장애물 생성
        // InvokeRepeating("SpawnEnemiesWithDelay", 0f, spawnInterval);

        // 코루틴 직접 시작
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 코루틴을 사용하여 적을 일정 시간 간격으로 여러 번 생성
    IEnumerator SpawnEnemiesWithDelay()
    {
        // 무한 루프 사용(반복적으로 적을 생성)
        while (true)
        {
            // 생성할 적의 개수 랜덤 결정(1~5개의 적 생성)
            int randomEnemyCount = Random.Range(1, 6);

            // 0에서 10 사이의 랜덤 값 생성
            // float randomValue = Random.Range(0f, 10f);

            /*
            
            // 생성할 위치 설정 (확률에 따라 위치 결정)
            float randomY = 0f;

            // 확률에 따라 Y위치 결정
            if (randomValue < 5f)   // 50% 확률로 아래로 적 생성
            {
                randomY = Random.Range(spawnPosMinY, spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.3f); // 아래
                Debug.Log("아래");
            }
            else if (randomValue < 8f)  // 40% 확률로 중간에 적 생성
            {
                randomY = Random.Range(spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.4f, spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.6f); // 가운데
                Debug.Log("중간");
            }
            else // 20% 확률로 위
            {
                randomY = Random.Range(spawnPosMinY + (spawnPosMaxY - spawnPosMinY) * 0.7f, spawnPosMaxY);
                Debug.Log("위");
            }

            */

            // X 범위 내에서 랜덤한 위치 생성 (오른쪽에서 생성)
            float randomX = Random.Range(spawnMinX, spawnMaxX); // spawnMinX = x축의 최솟값, spawnMaxX = x축의 최댓값
            spawnPosition = new Vector3(randomX, -2.5f, 0);  // spawnPosition 업데이트


            // 랜덤한 개수만큼 적 생성
            for (int i = 0; i < randomEnemyCount; i++)
            {
                // 첫 번째 적 생성
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // 각 적마다 랜덤한 시간 간격을 두고 생성
                float randomWaitTime = Random.Range(0.5f, 2f);
                yield return new WaitForSeconds(randomWaitTime);
            }

            // 일정 시간 간격으로 다시 반복되도록
            float randomSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(randomSpawnInterval); // 다음 스폰까지 랜덤 시간 대기
        }
    }
}