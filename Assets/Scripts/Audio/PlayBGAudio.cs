using UnityEngine;
public class PlayBGAudio : MonoBehaviour
{
    private AudioSource audioSource;
    bool isOn;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        isOn = true;
        if (GameManager.Instance.isOnMusic)
        {
            PlayAudioWithVolumn(0.1f, audioSource);
        }
    }
    private void Update()
    {
        if (GameManager.Instance.isOnMusic == false)
        {
            audioSource.Pause();
            isOn = false;
        }
        if(GameManager.Instance.isOnMusic == true && isOn == false)
        {
            audioSource.UnPause();
            isOn = true;
        }
    }
    public void PlayAudioWithVolumn(float volumn, AudioSource audioS)
    {
        audioS.volume = volumn;
        audioS.Play();
    }
}
