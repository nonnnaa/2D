using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
using System;
public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Instance;

    [Header("Game UI")]
    [SerializeField] private GameObject healthbar;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject gameOver_WinPanel;
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite On;
    [SerializeField] private Sprite Off;
    private void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        loadScene();
    }

    private void loadScene()
    {
        if(GameManager.Instance.isOnMusic) musicButton.image.sprite = On;
        else musicButton.image.sprite = Off;
    }

    void Update()
    {
        
    }
    // ---------------  Game  -----------------------
    public void SetHealthbar(float ratio)
    {
        healthbar.GetComponent<Image>().fillAmount = ratio;
    }
    public void SettingButton()
    {
        if (!setting.gameObject.activeSelf)
        {
            setting.gameObject.SetActive(true);
        }
    }

    public void SettingOpenMusic()
    {
        if (GameManager.Instance.isOnMusic)
        {
            musicButton.image.sprite = Off;
            GameManager.Instance.isOnMusic = false;
        }
        else
        {
            musicButton.image.sprite = On;
            GameManager.Instance.isOnMusic = true;
        }
    }
    public void Resume()
    {
        if (setting.gameObject.activeSelf)
        {
            setting.gameObject.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
    }
    public void GameOver_WinPanel(string s)
    {
        gameText.text = s;
        gameOver_WinPanel.SetActive(true);
    }
    public void Restart()
    {
        GameManager.Instance.LoadGame();
    }
    public void LoadHome()
    {
        SceneManager.LoadScene(0);
    }
    public GameObject getGameOver_WinPanel()
    {
        return gameOver_WinPanel;
    }
}
