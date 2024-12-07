using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/QuestData")]

public class QuestDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> Values = new List<V>();

        public void Add(K key, V value)
        {
            Keys.Add(key);
            Values.Add(value);
        }

        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = Values[i];
            }
            return dict;
        }
    }

    [SerializeField]
    public SerializableDictionary<string, bool> QuestData = new SerializableDictionary<string, bool>();

}
