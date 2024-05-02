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
    [SerializeField] private GameObject currentPlayer;

    public String isOnMusic = "On_Off";
    private string bestScore1_string = "bestScore1";
    private string bestScore2_string = "bestScore2";
    [SerializeField] private int currentFruits;
    [SerializeField] private int[] fruitsLevel;
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
        Debug.Log(PlayerPrefs.GetInt(bestScore1_string));
        Debug.Log(PlayerPrefs.GetInt(bestScore2_string));
        Debug.Log(PlayerPrefs.GetString(isOnMusic));
    }

    public string GetIsOnMusic()
    {
        return PlayerPrefs.GetString(isOnMusic);
    }
    public int getCurrentFruits() => currentFruits;
    public void setCurrentFruit(int mount) => currentFruits += mount;
    public int getFruitsLevel(int index) => fruitsLevel[index-1];
    public int getScore(int index)
    {
        if (index == 1) return PlayerPrefs.GetInt(bestScore1_string);
        else return PlayerPrefs.GetInt(bestScore2_string);
    }
    public string getCurrentStringBestScore(int index)
    {
        if (index == 1) return bestScore1_string;
        return bestScore2_string;
    }
    public Vector3 GetPlayerPosition() => currentPlayer.transform.position;
    public GameObject SetCurrentPlayer(GameObject player) => currentPlayer = player;
    public GameObject GetCurrentPlayer() => currentPlayer;
    public void LoadGame()
    {
        SceneManager.LoadScene(currentGameLevel);
        currentFruits = 0;

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
    public int getCurrentGameLevel() => currentGameLevel;
    public void GamePause() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;
    public void WinGame()
    {
        StartCoroutine("Win");
    }
    IEnumerator Win()
    {
        PlayerController.Instance.GetAnimator().SetTrigger("die");
        yield return new WaitForSeconds(0.3f);
        GamePlayUI.Instance.GameOver_WinPanel("Win !");
        currentPlayer.SetActive(false);
    }
}
