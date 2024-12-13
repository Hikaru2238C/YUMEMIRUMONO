using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintButtonManager : MonoBehaviour
{
    public GameObject targetPanel; // ボタンが操作するパネル
    public TMP_Text titleText;
    public TMP_Text mainText;
    public HintDataBase hintData;
    public TextAsset hintTextAsset;

    private HintDialogue hintDialogue;
    private void Start()
    {
        // ボタンがクリックされたときのイベントを設定
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        if (targetPanel != null)
        {
            targetPanel.SetActive(true); // パネルを表示
        }
        if (hintTextAsset != null)
        {
            // JSONデータを配列形式でデシリアライズ
            hintDialogue =  JsonUtility.FromJson<HintDialogue>(hintTextAsset.text);

            // `Contents`の中の`//n`を改行に変換
            string formattedContents = hintDialogue.Contents.Replace("//n", "\n");

            titleText.text = hintDialogue.Title;
            mainText.text = hintDialogue.Contents;
            mainText.text = formattedContents;
        }
        else
        {
            Debug.LogError($"JSONファイルが見つかりません！");
        }
    }
}
