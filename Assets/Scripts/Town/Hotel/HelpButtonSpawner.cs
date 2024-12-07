using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButtonSpawner : MonoBehaviour
{
    // Prefabを指定
    [SerializeField] GameObject HelpButtonPrefab;

    // 親オブジェクトを指定
    [SerializeField] Transform parentObject;

    //クエストデータを指定
    [SerializeField] HintDataBase hintDataBase;

    private void Start()
    {
        SpawnHelpButton();
    }
    public void SpawnHelpButton()
    {
        Dictionary<string, TextAsset> dict = hintDataBase.HintData.ToDictionary();

        //    foreach (var kvp in dict)
        //    {
        //        Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
        //        if (kvp.Value)
        //        {
        //            // idを設定
        //            string id = $"{kvp.Key}";

        //            // 生成するPrefabをIDに基づいて選択
        //            GameObject prefabToSpawn = null;
        //            if (id.StartsWith("バトル"))
        //            {
        //                prefabToSpawn = ButtleButtonPrefab;
        //            }
        //            else if (id.StartsWith("シナリオ") || id.StartsWith("sumple"))
        //            {
        //                prefabToSpawn = ScenarioeButtonPrefab;
        //            }
        //            // Prefabを生成し、親オブジェクトを指定
        //            GameObject childButton = Instantiate(prefabToSpawn, parentObject);
        //            //名前を設定
        //            childButton.name = id;

        //            // IDを格納するスクリプトがある場合に設定
        //            GateButtonID childID = childButton.GetComponent<GateButtonID>();
        //            if (childID != null)
        //            {
        //                childID.SetID(id);
        //            }
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
    }
}
