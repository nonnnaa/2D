using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float repeatTime;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("RepeatAnimation");
    }

    // Update is called once per frame
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
