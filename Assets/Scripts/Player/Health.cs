using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance;
    [SerializeField] private int currentHp;
    private int maxhp;
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

    private void Start()
    {
        maxhp = GameManager.Instance.getMaxHp();
        currentHp = maxhp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        { 
            GetDame(1);
        }
        if(collision.gameObject.CompareTag("Fruit"))
        {
            //AudioSource.PlayClipAtPoint(GameResourse.Instance.getAudioClip("collector"),
            //                            GameObject.FindGameObjectWithTag("MainCamera").transform.position);
            PlayBGAudio.Instance.PlayAudioWithVolumn(1, GameResourse.Instance.getAudioClip("collector"), GameManager.Instance.GetIsOnMusic());
            currentHp++;
            GameManager.Instance.setCurrentFruit(1);
            GamePlayUI.Instance.updateFruitsText();
            if (currentHp > maxhp) maxhp = currentHp;
            Destroy(collision.gameObject);
            GamePlayUI.Instance.SetHealthbar((float)currentHp / maxhp);
        }
    }
    public void GetDame(int dame)
    {
        //AudioSource.PlayClipAtPoint(GameResourse.Instance.getAudioClip("hit"),
        //                            GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        PlayBGAudio.Instance.PlayAudioWithVolumn(1, GameResourse.Instance.getAudioClip("hit"), GameManager.Instance.GetIsOnMusic());
        currentHp -= dame;
        GamePlayUI.Instance.SetHealthbar((float)currentHp / maxhp);
        PlayerController.Instance.GetAnimator().SetTrigger("GetDame");
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine("IDie");
    }
    IEnumerator IDie()
    {
        //AudioSource.PlayClipAtPoint(GameResourse.Instance.getAudioClip("lose"),
        //                            GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        PlayBGAudio.Instance.PlayAudioWithVolumn(1, GameResourse.Instance.getAudioClip("lose"), GameManager.Instance.GetIsOnMusic());
        PlayerController.Instance.GetAnimator().SetTrigger("die");
        yield return new WaitForSeconds(0.3f);
        GamePlayUI.Instance.GameOver_WinPanel("Lose !");
        gameObject.SetActive(false);
    }
    public int GetCurrentHp() => currentHp;
}
