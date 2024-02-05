using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float repeatTime;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("RepeatAnimation");
    }

    void Update()
    {

    }
    IEnumerator RepeatAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(repeatTime);
            animator.SetTrigger("play");
        }
    }
}