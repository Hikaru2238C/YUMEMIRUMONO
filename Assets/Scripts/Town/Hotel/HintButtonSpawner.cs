using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintButtonSpawner : MonoBehaviour
{
    // Prefabを指定
    [SerializeField] GameObject HelpButtonPrefab;

    // 親オブジェクトを指定
    [SerializeField] Transform parentObject;

    //クエストデータを指定
    [SerializeField] HintDataBase hintDataBase;

    //表示するヒントパネル
    [SerializeField] GameObject hintPanel;

    //ヒントのタイトル
    [SerializeField] TMP_Text titleText;

    //ヒントの本文
    [SerializeField] TMP_Text mainText;
    private void Start()
    {
        SpawnHelpButton();
    }
    public void SpawnHelpButton()
    {
        Dictionary<string, TextAsset> dict = hintDataBase.HintData.ToDictionary();

        foreach (var kvp in dict)
        {
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
            // idを設定
            string id = $"{kvp.Key}";

            // Prefabを生成し、親オブジェクトを指定
            GameObject childButton = Instantiate(HelpButtonPrefab, parentObject);
            //名前を設定
            childButton.name = id;

            // IDを格納するスクリプトがある場合に設定
            GetButtonID childID = childButton.GetComponent<GetButtonID>();
            if (childID != null)
            {
                childID.SetID(id);
            }
            // ButtonControllerに同じパネルを設定
            HintButtonManager hintButtonManager = childButton.GetComponent<HintButtonManager>();
            if (hintButtonManager != null)
            {
                hintButtonManager.targetPanel = hintPanel;
                hintButtonManager.titleText = titleText;
                hintButtonManager.mainText = mainText;
                hintButtonManager.hintData = hintDataBase;
                hintButtonManager.hintTextAsset = kvp.Value;
            }
        }
    }
}
