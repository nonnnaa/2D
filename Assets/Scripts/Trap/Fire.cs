using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Animator animator;
    [SerializeField] float delayTime;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Play");
    }
    IEnumerator Play()
    {
        animator.SetBool("on", true);
        yield return new WaitForSeconds(delayTime);
        animator.SetBool("on", false);
        yield return new WaitForSeconds(delayTime);
    }

}
