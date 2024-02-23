using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speedBullet;
    [SerializeField] private float delayAttack;
    [SerializeField] private bool canAttack;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
        }
    }
    IEnumerator Attack()
    {
        while (canAttack == true)
        {
            yield return new WaitForSeconds(delayAttack);
            animator.SetTrigger("attack");
        }
    }
    public void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        float tmp = Time.time;
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedBullet, ForceMode2D.Impulse);
    }
}
