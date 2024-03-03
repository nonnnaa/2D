using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Instance;

    [Header("Game UI")]
    [SerializeField] private GameObject healthbar;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject gameOver_WinPanel;
    [SerializeField] private GameObject ScoreUI;
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite On;
    [SerializeField] private Sprite Off;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    private float startTime, endTime;


    [SerializeField] private int best;
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
        startTime = Time.time;
    }

    private void loadScene()
    {
        if(GameManager.Instance.isOnMusic) musicButton.image.sprite = On;
        else musicButton.image.sprite = Off;
    }

    private void LoadScore()
    {
        int tmp_score = (int)(endTime - startTime);
        best = GameManager.Instance.getScore(GameManager.Instance.getCurrentGameLevel());
        scoreText.text = "New : " + tmp_score;
        bestScoreText.text = "Old : " + best;
        Debug.Log(best);
        if (tmp_score <= best)
        {
            PlayerPrefs.SetInt(GameManager.Instance.getCurrentStringBestScore(GameManager.Instance.getCurrentGameLevel()), tmp_score);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt(GameManager.Instance.getCurrentStringBestScore(1)));
            Debug.Log(PlayerPrefs.GetInt(GameManager.Instance.getCurrentStringBestScore(2)));
        }
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
        endTime = Time.time;
        gameOver_WinPanel.SetActive(true);
        if (s == "Win !")
        {
            ScoreUI.SetActive(true);
            LoadScore();
        }
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
