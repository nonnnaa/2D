using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    void Start()
    {
        var Player = Instantiate(GameManager.Instance.getCurrentPlayerPrefab(), transform.position, Quaternion.identity);
    }
}
