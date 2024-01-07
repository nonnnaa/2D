using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Charactor_Details", menuName = "Scriptable Objects/Charactor_Details")]
public class CharactorSO : ScriptableObject
{
    public string charactorName;
    public int maxHP;
    public GameObject charactorPrefab;
    public Sprite spriteCharactor;
}
