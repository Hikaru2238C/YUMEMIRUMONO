using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InHotelPanelBackButton : MonoBehaviour
{
    [SerializeField] GameObject inHintPanel;

    private void Start()
    {
        // ボタンがクリックされたときのイベントを設定
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        inHintPanel.SetActive(false);
    }
}
