using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform p1, p2;
    Vector3 dir;
    [SerializeField] private float moveSpeed;
    private void Start()
    {
        dir = p1.position - p2.position;
    }
    void Update()
    {
        if((transform.position.x - p1.position.x) <= 0.01f || (p2.position.x - transform.position.x) < 0.01f)
        {
            dir = -dir;
        }
        transform.position += dir.normalized * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health.Instance.GetDame(Health.Instance.GetCurrentHp());
        }
    }
}
