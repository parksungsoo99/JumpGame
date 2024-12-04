using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;  // ���� ǥ�� Text UI
    public float score = 0;         // ���� ����

    public GameObject gameOverUI;   // ���� ���� UI
    bool isGameOver = false;        // ���� ���� ����

    void Start()
    {
        gameOverUI.SetActive(false);    // ���� ���� UI �����
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;    // �ð��� ���� ���� ����
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString(); // ���� ǥ�� ������Ʈ
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
        // ���� ���� �ٽ� �ε��Ͽ� ���� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ���� ���� ���� Ȯ�� �޼���
    public bool IsGameOver()
    {
        return isGameOver;
    } 
}
