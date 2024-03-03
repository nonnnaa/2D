using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourse : MonoBehaviour
{
    public enum AudioClipEnum
    {
        // player audio
        jump,
        hit,
        collector,

        // game audio
        win,
        lose,

        // other
        kickButton
    }

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
    [SerializeField] private List<AudioClip> audioClip;
    public CharactorSO getCurrentInforCharactor(int id) 
    {
        return charactorInfor[id];
    }
    public AudioClip getAudioClip(string name)
    {
        switch (name)
        { 
            case "jump":
                return audioClip[0];
            case "hit":
                return audioClip[1];
            case "collector":
                return audioClip[2];
            case "win":
                return audioClip[3];
            case "lose":
                return audioClip[4];
            case "kickButton":
                return audioClip[5];
            case "appearing":
                return audioClip[6];
        }
        return null;
    }
}
