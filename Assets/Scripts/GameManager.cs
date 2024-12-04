using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;  // 점수 표시 Text UI
    public float score = 0;         // 점수 변수

    public GameObject gameOverUI;   // 게임 오버 UI
    bool isGameOver = false;        // 게임 오버 여부

    void Start()
    {
        gameOverUI.SetActive(false);    // 게임 오버 UI 숨기기
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;    // 시간에 따라 점수 증가
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString(); // 점수 표시 업데이트
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        // 현재 씬을 다시 로드하여 게임 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 게임 오버 상태 확인 메서드
    public bool IsGameOver()
    {
        return isGameOver;
    } 
}
