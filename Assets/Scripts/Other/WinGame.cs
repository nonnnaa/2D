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
        if(collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(GameResourse.Instance.getAudioClip("win"),
                                        Camera.main.transform.position);
            animator.SetTrigger("win");
            GameManager.Instance.WinGame();
            Debug.Log("va cham Goal!");
        }
    }
}
