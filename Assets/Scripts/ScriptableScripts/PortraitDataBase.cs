using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PortraitData")]
public class PortraitDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> PortraitImages = new List<V>();

        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = PortraitImages[i];
            }
            return dict;
        }
    }

    [Header("上には直接IDを、下にはPortraitをResorcesファイルから入れる")]
    [SerializeField]
    public SerializableDictionary<string, Sprite> PortraitData = new SerializableDictionary<string, Sprite>();
}
