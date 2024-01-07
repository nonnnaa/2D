using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public Button start, option, quit;
    void Start()
    {
        start = GetComponent<Button>();
        start.onClick.AddListener(onclick_startButton);
        option = GetComponent<Button>();
        option.onClick.AddListener(onclick_optionButton);
        quit = GetComponent<Button>();
        quit.onClick.AddListener(onclick_quitButton);
    }
    void onclick_startButton()
    {
        SceneManager.LoadScene(1);
    }
    void onclick_optionButton()
    {

    }
    void onclick_quitButton()
    {

    }
}
