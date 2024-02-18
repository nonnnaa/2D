using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public void ChangeHitSpriteColor()
    {
        if(Health.Instance.GetCurrentHp() >= 1f) gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void ResetSpriteColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
