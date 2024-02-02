using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private CharactorSO currentPlayerSO;
    [SerializeField] private int currentIndexCharactor;
    GameState currentState;


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
        currentState = GameState.home;
        currentIndexCharactor = 0;
        currentGameLevel = 1;
        currentPlayerSO = GameResourse.Instance.getCurrentInforCharactor(currentIndexCharactor);
    }
    private void UpdateGameState()
    {
        switch (currentState)
        {
            case GameState.home:
                Home();
                break;
            case GameState.playing:
                Playing();
                break;
            case GameState.pauseGame:
                PauseGame();
                break;
            case GameState.gameOver:
                GameOver();
                break;
            default:
                break;
        }
    }

    private void Playing()
    {
        throw new NotImplementedException();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(currentGameLevel);
        UIManager.Instance.Home.gameObject.SetActive(false);
        var initPlayer = Instantiate(currentPlayerSO.charactorPrefab, GameResourse.Instance.getPositionSpawnPlayer(0));
    }

    private void Home()
    {
        SceneManager.LoadScene(0);
        UIManager.Instance.Home.gameObject.SetActive(true);
    }
    private void GameOver()
    {
        Debug.Log("GameOver!");
    }

    public void PauseGame()
    {
        Debug.Log("GamePause!");
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Debug.Log("is Playing Game!");
        Time.timeScale = 1;
    }
    public int getMaxHp() => currentPlayerSO.maxHP;
    public int getCurrentIndexCharactor() => currentIndexCharactor;
    public void setCurrentIndexCharactor(int id)
    {
        currentIndexCharactor = id;
        currentPlayerSO = GameResourse.Instance.getCurrentInforCharactor(currentIndexCharactor);
    }
    public Sprite getCurrentPlayerSprite() => currentPlayerSO.spriteCharactor;
    public GameObject getCurrentPlayerPrefab() => currentPlayerSO.charactorPrefab;

    public void setCurrentGameLevel(int lv)
    {
        currentGameLevel = lv;
        Debug.Log($"Game level {lv}");
    }
}
