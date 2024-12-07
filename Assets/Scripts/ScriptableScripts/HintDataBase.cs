using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/HintData")]
public class HintDataBase : ScriptableObject
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        public List<K> Keys = new List<K>();
        public List<V> HintTextAsetts = new List<V>();

        public Dictionary<K, V> ToDictionary()
        {
            var dict = new Dictionary<K, V>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict[Keys[i]] = HintTextAsetts[i];
            }
            return dict;
        }
    }

    [Header("上には直接IDを、下にはヒントのテキストファイルを入れる")]
    [SerializeField]
    public SerializableDictionary<string, TextAsset> HintData = new SerializableDictionary<string, TextAsset>();
}
