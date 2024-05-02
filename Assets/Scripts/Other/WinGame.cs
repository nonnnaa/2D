using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" 
            && GameManager.Instance.getCurrentFruits() >= GameManager.Instance.getFruitsLevel(GameManager.Instance.getCurrentGameLevel()))
        {
            PlayBGAudio.Instance.PlayAudioWithVolumn(1, GameResourse.Instance.getAudioClip("win"), GameManager.Instance.GetIsOnMusic());
            animator.SetTrigger("win");
            GameManager.Instance.WinGame();
            Debug.Log("va cham Goal!");
        }
    }
}
