using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharactorSelection : MonoBehaviour
{
    public int index;
    public GameObject[] Charactors;
    public string[] CharactorNames;
    public Text NameCharactorSelected;
    public GameObject Panel;
    void Start()
    {
        index = 0;
        LoadCharactor();
    }
    public void NextCharactor()
    {
        if(index < Charactors.Length - 1)
        {
            index++;
        }
        LoadCharactor();
    }
    public void PrevCharactor()
    {
        if(index > 0)
        {
            index--;
        }
        LoadCharactor();
    }
    public void LoadCharactor()
    {
        for(int i=0; i<Charactors.Length;i++)
        {
            if(i == index)
            {
                Charactors[i].SetActive(true);
            }
            else
            {
                Charactors[i].SetActive(false);
            }
        }
        NameCharactorSelected.text = CharactorNames[index];
    }
    public void Setting()
    {
        Panel.SetActive(true);
    }
    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    }
}
