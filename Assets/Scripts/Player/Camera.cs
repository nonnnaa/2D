using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera.LookAt = GameManager.Instance.getCurrentPlayerPrefab().transform;
    }
}
