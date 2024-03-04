using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class HomeUI : MonoBehaviour
{
    public static HomeUI Instance;
    #region Header Home
    [Space(10)]
    [Header("Home")]
    [SerializeField] private GameObject selectLevel;
    [SerializeField] private Button right, left;
    [SerializeField] private Transform spawnCharactorPos;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private GameObject settingMusic;
    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite On;
    [SerializeField] private Sprite Off;
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
        }
    }
    void Start()
    { 
        StartCoroutine(LoadChar());
        loadScene();
    }

    private void loadScene()
    {
        DisplayTextLevel();
        if(PlayerPrefs.GetString(GameManager.Instance.isOnMusic) == "On") musicButton.image.sprite = On;
        else musicButton.image.sprite = Off;
    }

    public void SettingOpenMusic()
    {
        if (PlayerPrefs.GetString(GameManager.Instance.isOnMusic) == "On")
        {
            musicButton.image.sprite = Off;
            PlayerPrefs.SetString(GameManager.Instance.isOnMusic, "Off");
        }
        else
        {
            musicButton.image.sprite = On;
            PlayerPrefs.SetString(GameManager.Instance.isOnMusic, "On");
        }
        PlayerPrefs.Save();
    }
    public IEnumerator LoadChar()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) Destroy(GameObject.FindGameObjectWithTag("Player"));
        yield return new WaitForSeconds(0f);
        GameObject newChar = Instantiate(GameManager.Instance.getCurrentPlayerPrefab(), spawnCharactorPos.position, Quaternion.identity);
        newChar.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        newChar.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        newChar.GetComponent<PlayerController>().setGround(LayerMask.NameToLayer("Everything"));

    }
    public void NextCharactor()
    {
        int id = GameManager.Instance.getCurrentIndexCharactor() + 1;
        if (id > 3) id = 0;
        GameManager.Instance.setCurrentIndexCharactor(id);
        StartCoroutine(LoadChar());
    }
    public void PreviousCharactor()
    {
        int id = GameManager.Instance.getCurrentIndexCharactor() - 1;
        if (id < 0) id = 3;
        GameManager.Instance.setCurrentIndexCharactor(id);
        StartCoroutine(LoadChar());
    }


    public void ChooseLevel1()
    {
        GameManager.Instance.setCurrentGameLevel(1);
        DisplayTextLevel();
    }
    public void ChooseLevel2()
    {
        GameManager.Instance.setCurrentGameLevel(2);
        DisplayTextLevel();
    }
    public void DisplayTextLevel()
    {
        levelText.text = "Lv " + GameManager.Instance.getCurrentGameLevel().ToString();
    }
    public void StartGame()
    {
        GameManager.Instance.LoadGame();
    }
    public void SettingButton()
    {
        if (settingMusic.activeSelf)
        {
            settingMusic.gameObject.SetActive(false);
        }
        else settingMusic.gameObject.SetActive(true);
        Debug.Log("Setting Game!");
    }
    public void ExitGameButton()
    {
        Debug.Log("Exit Game!");
        Application.Quit();
    }
    public void ChooseLevelPanel()
    {
        if (selectLevel.gameObject.activeSelf) selectLevel.SetActive(false);
        else selectLevel.SetActive(true);
    }
}
