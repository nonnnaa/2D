using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBG : MonoBehaviour
{
    [SerializeField] private Vector2 v;
    private Material material;
    Vector2 offset;
    private void Start()
    {
        material = GetComponent<Material>();
    }
    private void Update()
    {
        offset = v * Time.deltaTime;
        if (offset.x >= 4.435) offset = Vector2.zero;
        material.mainTextureOffset += offset;

    }
}
