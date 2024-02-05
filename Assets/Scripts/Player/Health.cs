using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHp;
    private bool isInvincible = false;
    private int maxhp;
    
    private void Start()
    {
        maxhp = GameManager.Instance.getMaxHp();
        currentHp = maxhp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (!isInvincible)
            {
                isInvincible = true;
                TakeDame();
                StartCoroutine(EnableColliderAfterDelay(collision.gameObject.GetComponent<BoxCollider2D>(), 1.3f));
            }
        }
        if(collision.gameObject.CompareTag("Fruit"))
        {
            currentHp++;
            Destroy(collision.gameObject);
            GamePlayUI.Instance.SetHealthbar((float)currentHp / maxhp);
        }
    }

    private IEnumerator EnableColliderAfterDelay(BoxCollider2D collider, float delay)
    {
        collider.enabled = false;
        yield return new WaitForSeconds(delay);
        collider.enabled = true;
        isInvincible = false;
    }

    private void TakeDame()
    {
        currentHp--;
        GamePlayUI.Instance.SetHealthbar((float)currentHp / maxhp);
        PlayerController.Instance.anim.SetTrigger("GetDame");
        if (currentHp <= 0) Die();
    }


    private void Die()
    {
        Debug.Log("Game Over!");
    }
}
