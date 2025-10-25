using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton

    [Header("Game Data")]
    public int currentStage = 1;
    public int score = 0;

    [Header("�÷��̾� ������ ����")]
    public int playerMaxHP = 100;
    public int playerCurrentHP = 100;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���� �ڵ�� (�ʿ�� ���)
    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SetStage(int stage)
    {
        currentStage = stage;
    }

    public void InitPlayerHP(int maxHP)
    {
        playerMaxHP = maxHP;
        playerCurrentHP = maxHP;
    }
}
