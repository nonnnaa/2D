using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private CharactorSO currentPlayerSO;
    [SerializeField] private int currentIndexCharactor;
    [SerializeField] private int currentGameLevel;

    private void Awake()
    {

        if (Instance != null && this != Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        currentPlayerSO = GameResourse.Instance.getCurrentInforCharactor(currentIndexCharactor);
    }

    public void LoadGame() => SceneManager.LoadScene(currentGameLevel);
    public int getMaxHp() => currentPlayerSO.maxHP;
    public int getCurrentIndexCharactor() => currentIndexCharactor;
    public void setCurrentIndexCharactor(int id)
    {
        currentIndexCharactor = id;
        currentPlayerSO = GameResourse.Instance.getCurrentInforCharactor(currentIndexCharactor);
    }
    public Sprite getCurrentPlayerSprite() => currentPlayerSO.spriteCharactor;
    public GameObject getCurrentPlayerPrefab() => currentPlayerSO.charactorPrefab;
    public String getCurrentPlayerName() => currentPlayerSO.name;
    public void setCurrentGameLevel(int lv)
    {
        currentGameLevel = lv;
        Debug.Log($"Game level {lv}");
    }
    public void GamePause() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;
    public void GameOver_Win(String check)
    {
        GamePlayUI.Instance.GameOver_WinPanel(check);
    }
}
