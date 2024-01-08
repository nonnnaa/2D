using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourse : MonoBehaviour
{
    public static GameResourse Instance { get; private set; }
    private void Awake()
    {

        if(Instance != null && this != Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    [SerializeField] private List<CharactorSO> charactorInfor;

    [SerializeField] private List<Item> listItem;
    public CharactorSO getCurrentInforCharactor(int id)
    {
        return charactorInfor[id];
    }
}
