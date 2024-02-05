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
    public List<CharactorSO> charactorInfor;
    public List<Item> listItem;
    public CharactorSO getCurrentInforCharactor(int id) 
    {
        return charactorInfor[id];
    }
}
