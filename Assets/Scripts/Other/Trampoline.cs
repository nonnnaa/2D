using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] private float jumpPow;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Jump(collision.gameObject));
    }
    IEnumerator Jump(GameObject player)
    {
        anim.SetTrigger("jump");
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
    }
}
