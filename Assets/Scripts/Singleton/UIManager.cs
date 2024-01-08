using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    // Game1 UI
    #region Header Game1 UI
    [Space(10)]
    [Header("Game1 UI")]
    #endregion
    [SerializeField] public GameObject healthbar;
    [SerializeField] private GameObject setting;

    [SerializeField] private bool isOpenMusic;
    [SerializeField] private Image On;
    [SerializeField] private Image Off;
    // Home UI
    #region Header Home
    [Space(10)]
    [Header("Home")]
    #endregion
    [SerializeField] private Button right, left;
    [SerializeField] private GameObject SpawnCharactorPos;

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
        SpawnCharactorPos.gameObject.GetComponent<Image>().sprite = GameManager.Instance.getCurrentPlayerSprite();
    }
    // Game1
    public void setHealthbar(float ratio)
    {
        healthbar.GetComponent<Image>().fillAmount = ratio;
    }
    public void SettingButton()
    {
        setting.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void SettingOpenMusic()
    {
        if(isOpenMusic == true)
        {
            On.gameObject.SetActive(false);
            Off.gameObject.SetActive(true);
            isOpenMusic = false;
        }
        else
        {
            On.gameObject.SetActive(true);
            Off.gameObject.SetActive(false);
            isOpenMusic = true;
        }
    }
    public void LoadHome()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void Resume()
    {
        setting.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Game1()
    {
        SceneManager.LoadScene("Game1");

    }

    // Home
    public void nextCharactor()
    {
        int id = GameManager.Instance.getCurrentIndexCharactor() + 1;
        if (id > 3) id = 0;
        GameManager.Instance.setCurrentIndexCharactor(id);
        SpawnCharactorPos.gameObject.GetComponent<Image>().sprite = GameManager.Instance.getCurrentPlayerSprite();
    }
    public void previousCharactor()
    {
        int id = GameManager.Instance.getCurrentIndexCharactor() - 1;
        if (id < 0) id = 3;
        GameManager.Instance.setCurrentIndexCharactor(id);
        SpawnCharactorPos.gameObject.GetComponent<Image>().sprite = GameManager.Instance.getCurrentPlayerSprite();
    }

}