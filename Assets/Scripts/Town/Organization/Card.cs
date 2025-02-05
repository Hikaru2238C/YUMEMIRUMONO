using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class Card :ScriptableObject
{
    public string cardName;//名前
    public string cardDescription;//説明
    public string cardImagePath;//画像パス
}
