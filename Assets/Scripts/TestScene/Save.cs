using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button increase;
    [SerializeField] private Button decrease;
    [SerializeField] private TextMeshProUGUI point;


    private string point_text = "point_save";

    [SerializeField] private int p;
    void Start()
    {
        LoadPoint();
    }

    public void Increase()
    {
        p++;
        point.text = p.ToString();
        Debug.Log("increase");
    }
    public void Decrease()
    {
        p--;
        point.text = p.ToString();
        Debug.Log("decrease");
    }
    public void SavePoint()
    {
        PlayerPrefs.SetInt(point_text, p);
        point.text = p.ToString();
        PlayerPrefs.Save();
        Debug.Log("Save : " + p);
    }
    public void LoadPoint()
    {
        p = PlayerPrefs.GetInt(point_text);
        PlayerPrefs.Save();
        point.text = p.ToString();
        Debug.Log("Load : " + p);
    }
}
