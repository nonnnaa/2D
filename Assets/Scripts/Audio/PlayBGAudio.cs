using UnityEngine;

public class PlayBGAudio : MonoBehaviour
{
    AudioSource audio;
    bool isOn;
    void Start()
    {
        audio = GetComponent<AudioSource>();    
        if(GameManager.Instance.isOnMusic) audio.Play();
    }
    private void Update()
    {
        if (Health.Instance.GetCurrentHp() <= 0 || GameManager.Instance.isOnMusic == false)
        {
            audio.Pause();
            GameManager.Instance.isOnMusic = false;
            isOn = false;
        }
        if(GameManager.Instance.isOnMusic == true && isOn == false)
        {
            audio.UnPause();
            isOn = true;
        }
    }
}
