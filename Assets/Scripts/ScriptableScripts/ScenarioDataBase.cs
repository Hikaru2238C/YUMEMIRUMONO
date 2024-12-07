using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ScenarioData")]
public class ScenarioDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> TextAseets = new List<V>();

        public void Add(K key, V value)
        {
            Keys.Add(key);
            TextAseets.Add(value);
        }

        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = TextAseets[i];
            }
            return dict;
        }

        //public void FromDictionary(Dictionary<K, V> dict)
        //{
        //    Keys.Clear();
        //    TextAseets.Clear();
        //    foreach (var kvp in dict)
        //    {
        //        Keys.Add(kvp.Key);
        //        TextAseets.Add(kvp.Value);
        //    }
        //}
    }
    [Header("上には直接IDを、下にはJsonファイルをResorcesファイルから入れる")]
    [SerializeField]
    public SerializableDictionary<string, TextAsset> ScenarioData = new SerializableDictionary<string, TextAsset>();

}
