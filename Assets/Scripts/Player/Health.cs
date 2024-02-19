using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance;
    [SerializeField] private float currentHp;
    [SerializeField] private bool isInvincible;
    private int maxhp;
    private void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

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
                GetDame(1);
                isInvincible = false;
            }
        }
        if(collision.gameObject.CompareTag("Fruit"))
        {
            currentHp++;
            Destroy(collision.gameObject);
            GamePlayUI.Instance.SetHealthbar((float)currentHp / maxhp);
        }
    }
    public void GetDame(float dame)
    {
        currentHp -= dame;
        GamePlayUI.Instance.SetHealthbar((float)currentHp / maxhp);
        PlayerController.Instance.GetAnimator().SetTrigger("GetDame");
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine("IDie");
    }
    IEnumerator IDie()
    {
        PlayerController.Instance.GetAnimator().SetTrigger("die");
        yield return new WaitForSeconds(0.3f);
        GamePlayUI.Instance.GameOver_WinPanel("Lose !");
        gameObject.SetActive(false);
    }
    public bool GetIsInvisible() => isInvincible;
    public float GetCurrentHp() => currentHp;
}
