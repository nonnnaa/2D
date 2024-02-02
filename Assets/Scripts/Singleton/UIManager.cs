using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    #region Header Game UI
    [Space(10)]
    [Header("Game UI")]
    [SerializeField] public GameObject healthbar;
    [SerializeField] private GameObject setting;
    #endregion

    [SerializeField] private bool isOpenMusic;
    [SerializeField] private Image On;
    [SerializeField] private Image Off;

    #region Header Home
    [Space(10)]
    [Header("Home")]
    [SerializeField] public GameObject Home;
    [SerializeField] private GameObject selectLevel;
    [SerializeField] private Button right, left;
    [SerializeField] private GameObject SpawnCharactorPos;
    #endregion

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
    public void SetHealthbar(float ratio)
    {
        healthbar.GetComponent<Image>().fillAmount = ratio;
    }
    public void SettingButton()
    {
        setting.gameObject.SetActive(true);
        GameManager.Instance.PauseGame();
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
    public void Resume()
    {
        setting.gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }

    // Home
    public void NextCharactor()
    {
        int id = GameManager.Instance.getCurrentIndexCharactor() + 1;
        if (id > 3) id = 0;
        GameManager.Instance.setCurrentIndexCharactor(id);
        SpawnCharactorPos.gameObject.GetComponent<Image>().sprite = GameManager.Instance.getCurrentPlayerSprite();
    }
    public void PreviousCharactor()
    {
        int id = GameManager.Instance.getCurrentIndexCharactor() - 1;
        if (id < 0) id = 3;
        GameManager.Instance.setCurrentIndexCharactor(id);
        SpawnCharactorPos.gameObject.GetComponent<Image>().sprite = GameManager.Instance.getCurrentPlayerSprite();
    }


    public void ChooseLevel1() => GameManager.Instance.setCurrentGameLevel(1);
    public void ChooseLevel2() => GameManager.Instance.setCurrentGameLevel(2);
    public void StartGame()
    {
        GameManager.Instance.LoadGame();
    }
    public void ChooseLevelPanel()
    {
        if(selectLevel.gameObject.activeSelf) selectLevel.SetActive(false);
        else selectLevel.SetActive(true);
    }

}