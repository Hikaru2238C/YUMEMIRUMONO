using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailPanel : MonoBehaviour
{
    public TMP_Text cardNameText;
    public TMP_Text cardDescriptionText;
    public Image cardImage;
    public GameObject panel; // パネルのGameObject（表示・非表示を切り替える）
    public GameObject panel2; // パネルのGameObject（表示・非表示を切り替える）

    // カードの詳細を表示する関数
    public void ShowCardDetail(Card card)
    {
        cardNameText.text = card.cardName;
        cardDescriptionText.text = card.cardDescription; // Cardクラスに説明を追加する
        //cardImage.sprite = Resources.Load<Sprite>(card.cardImagePath); // 画像読み込み
        panel.SetActive(true);
    }

    //デッキの詳細を表示する関数
    public void ShowDeckDetail()
    {
        panel2.SetActive(true);
    }
    // 閉じるボタンでパネルを非表示にする
    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
