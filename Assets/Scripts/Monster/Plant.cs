using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speedBullet;
    [SerializeField] private float delayAttack;
    [SerializeField] private bool canAttack;
    [SerializeField] private List<GameObject> bulletPool;
    [SerializeField] private int amountToPool;
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
        if(bulletPool.Count < amountToPool)
        {
            var bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
            float tmp = Time.time;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedBullet, ForceMode2D.Impulse);
            bulletPool.Add(bullet);
        }
        else
        {
            foreach(var bullet in bulletPool)
            {
                if(!bullet.gameObject.activeInHierarchy)
                {
                    bullet.SetActive(true);
                    bullet.gameObject.GetComponent<Transform>().position = firePos.position;
                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedBullet, ForceMode2D.Impulse);
                    break;
                }
            }
        }
    }
}
