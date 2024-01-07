using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] public GameObject healthbar;
    [SerializeField] private GameObject setting;

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
            DontDestroyOnLoad(gameObject);
        }
    }
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
        SceneManager.LoadScene("Home");
    }
    public void Resume()
    {
        setting.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
