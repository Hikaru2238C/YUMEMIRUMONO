using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BGMData")]
public class BGMDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> BGM = new List<V>();

        public void Add(K key, V value)
        {
            Keys.Add(key);
            BGM.Add(value);
        }
        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = BGM[i];
            }
            return dict;
        }
    }
    [Header("上には直接IDを、下にはBGMをResorcesファイルから入れる")]
    [SerializeField]
    public SerializableDictionary<string, AudioClip> BGMData = new SerializableDictionary<string, AudioClip>();

}