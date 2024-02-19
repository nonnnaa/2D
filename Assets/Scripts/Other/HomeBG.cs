using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBG : MonoBehaviour
{
    [SerializeField] private Vector2 v;
    private Material material;
    private Vector2 offset;
    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        offset = v * Time.deltaTime;
        material.mainTextureOffset += offset;
        if (material.mainTextureOffset.x > 100f) material.mainTextureOffset = Vector2.zero;
    }
}
