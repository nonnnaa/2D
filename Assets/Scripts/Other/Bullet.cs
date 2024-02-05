using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeToDestroyBullet;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - t > timeToDestroyBullet)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health.Instance.TakeDame(1);
        }
    }
}
