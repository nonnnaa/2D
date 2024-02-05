using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation animationComponent;
    public AnimationClip myAnimationClip;
    void Start()
    {
        animationComponent.clip = myAnimationClip;
        animationComponent.Play();
        var player = Instantiate(GameManager.Instance.getCurrentPlayerPrefab(), transform.position, Quaternion.identity);
        player.name = "Player";
        player.tag = "Player";
    }
}
