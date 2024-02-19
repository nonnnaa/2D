using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChameleon : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private float distanceCheck;
    [SerializeField] private float distanceStop;
    [SerializeField] private float speedMove;
    [SerializeField] private float delayTimeAttack;
    [SerializeField] private bool canAttack;
    [SerializeField] private bool isRun;
    [SerializeField] bool isFacingRight;
    private Animator animator;
    private Rigidbody2D rb;


    [SerializeField] private float dis;
    Vector2 dir;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Condition();
        UpdateAnim();
    }

    private void Condition()
    {
        dir = (GameManager.Instance.GetCurrentPlayer().transform.position - gameObject.transform.position);
        dis = dir.magnitude;
        if(dis < distanceCheck)
        {
            isRun = true;
            if (dis < distanceStop)
            {
                isRun = false;
            }
        }else isRun = false;
    }
    private void UpdateAnim()
    {
        animator.SetBool("run", isRun);
    }
    private void FixedUpdate()
    {
        PhysicUpdate();
    }
    IEnumerator Attack()
    {
        while(canAttack == true)
        {
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(delayTimeAttack);
        }
    }
    private void PhysicUpdate()
    {
        if (isRun)
        {
            rb.velocity = dir.normalized * speedMove * Time.deltaTime;
        }
        else rb.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canAttack = true;
            StartCoroutine("Attack");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canAttack = false;
            StartCoroutine("ReturnStartPos");
        }
    }

    IEnumerator ReturnStartPos()
    {
        while (transform.position != startPos)
        {
            Vector2 direc = (startPos - transform.position).normalized;
            rb.velocity = direc * speedMove * Time.deltaTime;
            yield return null;
        }
    }
    public void Die()
    {
        StartCoroutine("IDie");
    }
    IEnumerator IDie()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
