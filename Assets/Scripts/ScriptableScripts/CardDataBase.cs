using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CardData")]
public class CardDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> BackgrondImages = new List<V>();

        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = BackgrondImages[i];
            }
            return dict;
        }
    }

    [Header("上には直接IDを、下にはBackgoundをResorcesファイルから入れる")]
    [SerializeField]
    public SerializableDictionary<string, Sprite> BackgroundData = new SerializableDictionary<string, Sprite>();
}
