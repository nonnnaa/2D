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


    public bool isOnMusic;
    
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

    public Vector3 GetPlayerPosition() => currentPlayer.transform.position;
    public GameObject SetCurrentPlayer(GameObject player) => currentPlayer = player;
    public GameObject GetCurrentPlayer() => currentPlayer;
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
