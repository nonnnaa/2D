using UnityEngine;
public class PlayBGAudio : MonoBehaviour
{
    public static PlayBGAudio Instance;
    [SerializeField] private AudioSource audioSourceBG;
    [SerializeField] private AudioSource audioSourceSfx;
    private void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    { 
        if (GameManager.Instance.GetIsOnMusic() == "On")
        {
            PlayAudioWithVolumn(0.1f, audioSourceBG.clip, "On");
        }
    }
    private void Update()
    {
        if (GameManager.Instance.GetIsOnMusic() == "Off")
        {
            audioSourceBG.Pause();
        }
        if(GameManager.Instance.GetIsOnMusic() == "On")
        {
            audioSourceBG.UnPause();
        }
    }
    public void PlayAudioWithVolumn(float volumn, AudioClip audio, string isPlay)
    {
        if(isPlay == "On")
        {
            audioSourceSfx.clip = audio;
            audioSourceSfx.volume = volumn;
            audioSourceSfx.Play();
        }
    }
}
