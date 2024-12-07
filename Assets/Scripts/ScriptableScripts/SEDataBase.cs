using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SEData")]
public class SEDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> SE = new List<V>();

        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = SE[i];
            }
            return dict;
        }
    }

    [Header("上には直接IDを、下にはSEをResorcesファイルから入れる")]
    [SerializeField]
    public SerializableDictionary<string, AudioClip> SEData = new SerializableDictionary<string, AudioClip>();
}
