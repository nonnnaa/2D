using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Instance;
    #region Header Game UI
    [Space(10)]
    [Header("Game UI")]
    [SerializeField] private GameObject healthbar;
    [SerializeField] private GameObject setting;
    #endregion

    [SerializeField] private bool isOpenMusic;
    [SerializeField] private Image On;
    [SerializeField] private Image Off;
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
            GameManager.Instance.GamePause();
        }
    }
    public void SettingOpenMusic()
    {
        if (isOpenMusic == true)
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
        if (setting.gameObject.activeSelf)
        {
            setting.gameObject.SetActive(false);
            GameManager.Instance.ResumeGame();
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
}
