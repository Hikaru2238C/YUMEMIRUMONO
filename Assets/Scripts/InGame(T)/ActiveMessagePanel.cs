using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ActiveMessagePanel : MonoBehaviour
{
    //　MessageUIに設定されているMessageスクリプトを設定
    [SerializeField]
    private MessageScript messageScript;

    //　表示させるメッセージ
    private string message = "かかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかか"
                             + "ききききききききききききききききききききききききききききききききききききききききききききききききききききききき\n"
                             + "くくくくく\n"
                             + "けけけけけけけけけけけけ";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //messageScript.SetMessagePanel(message);
        }
    }
}
