using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCardButton : MonoBehaviour
{
    [SerializeField] GameObject RegistrationButton;
    [SerializeField] GameObject DeleteButton;
    GameObject buttonPrefab;   // ボタンのプレハブを指定
    Transform parentPanel;    // 初期の親パネル（例: PanelA）
    Transform targetPanel;    // 移動先のパネル（例: PanelB）

    //GameObject parentPanel;

    //1,生成される
    //2,所属パネルを取得、応じて出現ボタンを設定
    //3,登録を押された処理
    //4,削除を押された処理
    private void Start()
    {
        Transform parentObject = gameObject.transform.parent.parent; // 親オブジェクトを取得
        if(parentObject.name == "PossessionContent")
        {
            RegistrationButton.SetActive(true);
            DeleteButton.SetActive(false);
        }
        else
        {
            RegistrationButton.SetActive(false);
            DeleteButton.SetActive(true);
        }
    }
    public void InCardButtonClick()
    {

    }

    public void OnRegistrationClick(GameObject buttonObject)
    {
        // 親オブジェクトを移動
        Transform parentObject = buttonObject.transform.parent; // 親オブジェクトを取得
        parentObject.SetParent(targetPanel, false); // 移動先パネルの子に設定
        RegistrationButton.SetActive(false);
        DeleteButton.SetActive(true);
        Debug.Log("ボタンとその親オブジェクトを移動しました！");
    }

    public void OnDeleteClick(GameObject buttonObject)
    {
        // 親オブジェクトを移動
        Transform parentObject = buttonObject.transform.parent; // 親オブジェクトを取得
        parentObject.SetParent(targetPanel, false); // 移動先パネルの子に設定
        RegistrationButton.SetActive(true);
        DeleteButton.SetActive(false);
        Debug.Log("ボタンとその親オブジェクトを移動しました！");
    }
}
