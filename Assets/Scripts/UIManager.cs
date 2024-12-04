using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 옵션 화면과 리더보드 화면을 위한 UI 오브젝트
    public GameObject optionPanel;
    public GameObject leaderboardPanel;

    // StartGame 버튼 클릭
    public void StartGame()
    {
        // 게임을 시작하는 씬으로 이동
        SceneManager.LoadScene("GameScene");
    }

    // Option 버튼 클릭
    public void ShowOptions()
    {
        // Option 패널을 표시
        optionPanel.SetActive(true);
    }

    // Leaderboards 버튼 클릭
    public void ShowLeaderboards()
    {
        // Leaderboard 패널을 표시
        leaderboardPanel.SetActive(true);

        // 리더보드 데이터를 표시하는 코드를 추가할 수 있음

    }

    // Option 화면을 닫는 메서드
    public void CloaseOptions()
    {
        optionPanel.SetActive(false);
    }

    // Leaderboard 화면을 닫는 메서드
    public void CloseLeaderboards()
    {
        leaderboardPanel.SetActive(false);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
