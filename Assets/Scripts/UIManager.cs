using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // �ɼ� ȭ��� �������� ȭ���� ���� UI ������Ʈ
    public GameObject optionPanel;
    public GameObject leaderboardPanel;

    // StartGame ��ư Ŭ��
    public void StartGame()
    {
        // ������ �����ϴ� ������ �̵�
        SceneManager.LoadScene("GameScene");
    }

    // Option ��ư Ŭ��
    public void ShowOptions()
    {
        // Option �г��� ǥ��
        optionPanel.SetActive(true);
    }

    // Leaderboards ��ư Ŭ��
    public void ShowLeaderboards()
    {
        // Leaderboard �г��� ǥ��
        leaderboardPanel.SetActive(true);

        // �������� �����͸� ǥ���ϴ� �ڵ带 �߰��� �� ����

    }

    // Option ȭ���� �ݴ� �޼���
    public void CloaseOptions()
    {
        optionPanel.SetActive(false);
    }

    // Leaderboard ȭ���� �ݴ� �޼���
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
