using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDie : MonoBehaviour
{
    [SerializeField] private GameObject chameleon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            chameleon.GetComponent<AIChameleon>().Die();
        }
    }
}
