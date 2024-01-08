using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private CharactorSO currentPlayerSO;
    [SerializeField] private int currentIndexCharactor;
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
        currentIndexCharactor = 0;
        currentPlayerSO = GameResourse.Instance.getCurrentInforCharactor(currentIndexCharactor);
    }
    public int getMaxHp()
    {
        return currentPlayerSO.maxHP;
    }
    public int getCurrentIndexCharactor()
    {
        return currentIndexCharactor;
    }
    public void setCurrentIndexCharactor(int id)
    {
        currentIndexCharactor = id;
        currentPlayerSO = GameResourse.Instance.getCurrentInforCharactor(currentIndexCharactor);
    }
    public Sprite getCurrentPlayerSprite()
    {
        return currentPlayerSO.spriteCharactor;
    }
    public GameObject getCurrentPlayerPrefab()
    {
        return currentPlayerSO.charactorPrefab;
    }
}
