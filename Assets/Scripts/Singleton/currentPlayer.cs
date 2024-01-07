using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class currentPlayer : MonoBehaviour
{
    public static currentPlayer Instance { get; private set; }

    [SerializeField] private CharactorSO charactorInfo;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public int getMaxHp()
    {
        return charactorInfo.maxHP;
    }
}
