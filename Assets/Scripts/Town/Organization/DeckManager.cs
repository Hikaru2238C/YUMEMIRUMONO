using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using Unity.VisualScripting;

public class DeckManager : MonoBehaviour
{
    [SerializeField] Card attackCard;
    [SerializeField] Card defenseCard;
    public GameObject possessionCardButtonPrefab; // カードボタンのプレハブ
    public GameObject deckCardButtonPrefab; // カードボタンのプレハブ
    public GameObject deckDetailCardButtonPrefab; // カードボタンのプレハブ
    public CardDetailPanel cardDetailPanel;//カード詳細のパネル
    public Transform allCardsPanel; // 所持カードを表示するUIの親オブジェクト
    public Transform deckPanel; // デッキ内のカードを表示するUIの親オブジェクト
    public Transform deckDetailPanel;
    public List<Card> allCards = new List<Card>(); // 所持カードリスト
    public Deck playerDeck = new Deck(); // プレイヤーのデッキ

    private string deckFilePath;

    void Start()
    {
        deckFilePath = Path.Combine(Application.persistentDataPath, "playerDeck.json");

        //if (playerDeck == null)
        //{
        //    playerDeck = new Deck();
        //}
        InitializeDefaultDeck();

        LoadDeck(); // ゲーム開始時にデッキを読み込む


        // デッキが空であれば初期化
        if (playerDeck == null || playerDeck.deckCards == null || playerDeck.deckCards.Count == 0)
        {
            Debug.Log("Deck is empty. Initializing default deck.");
            InitializeDefaultDeck();
        }
        else
        {
            Debug.Log("Deck loaded successfully with " + playerDeck.deckCards.Count + " cards.");
        }
        DisplayAllCards(); // 所持カードを表示
        DisplayDeckCards(); // デッキ内のカードを表示
        DetailDeckCards();
    }

    // 初期状態のデッキを作成
    void InitializeDefaultDeck()
    {
        Debug.Log("Initializing default deck...");

        // 攻撃カードを15枚追加
        for (int i = 0; i < 15; i++)
        {
            //Card attackCard = new Card
            //{
            //    cardName = "攻撃Lv1 ",
            //    cardDescription = "敵1体に20前後のダメージを与えます その後、カードを1枚引きます 戦闘を進行するための重要なカードです 十分にデッキに登録しておきましょう",
            //    cardImagePath = null // ここに攻撃カードのデフォルト画像を設定
            //};
            playerDeck.deckCards.Add(attackCard);
            //allCards.Add(attackCard); // 所持カードにも追加
        }

        // 防御カードを5枚追加
        for (int i = 0; i < 5; i++)
        {
            //Card defenseCard = new Card
            //{
            //    cardName = "防御Lv1 ",
            //    cardDescription = "敵1体に20前後のダメージを与えます その後、カードを1枚引きます 戦闘を進行するための重要なカードです 十分にデッキに登録しておきましょう",
            //    cardImagePath = null // ここに防御カードのデフォルト画像を設定
            //};
            playerDeck.deckCards.Add(defenseCard);
            //allCards.Add(defenseCard); // 所持カードにも追加
        }

        SaveDeck(); // 初期デッキを保存
        Debug.Log("Default deck initialized with 30 cards.");
    }

    // デッキをJSONファイルに保存
    public void SaveDeck()
    {
        string json = JsonUtility.ToJson(playerDeck);
        File.WriteAllText(deckFilePath, json);
        Debug.Log("Deck saved to " + deckFilePath);
    }

    // JSONファイルからデッキを読み込む
    public void LoadDeck()
    {
        if (File.Exists(deckFilePath))
        {
            try
            {
                string json = File.ReadAllText(deckFilePath);
                playerDeck = JsonUtility.FromJson<Deck>(json);
                Debug.Log("Deck loaded successfully." + deckFilePath);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error loading deck: " + ex.Message);
                playerDeck = new Deck();
            }
        }
        else
        {
            Debug.Log("No saved deck found. Creating a new deck.");
            playerDeck = new Deck();
        }
    }

    // 所持カードをUIに表示
    void DisplayAllCards()
    {
        foreach (Transform child in allCardsPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in allCards)
        {
            GameObject cardButton = Instantiate(possessionCardButtonPrefab, allCardsPanel);
            cardButton.GetComponentInChildren<TMP_Text>().text = card.cardName;
            //cardButton.GetComponent<Image>().sprite = card.cardImage;
            Button[] buttons = cardButton.GetComponentsInChildren<Button>();
            if (buttons.Length >= 2)
            {
                Button firstButton = buttons[0];  // 一番目のボタン
                Button secondButton = buttons[1]; // 二番目のボタン

                firstButton.onClick.AddListener(() => cardDetailPanel.ShowCardDetail(card)); //Debug.Log("カード詳細"));
                secondButton.onClick.AddListener(() => OnCardClicked(card, true));
                secondButton.onClick.AddListener(() => Destroy(cardButton));
            }
            //button.onClick.AddListener(() => OnCardClicked(card, true));
        }
    }

    // デッキ内のカードをUIに表示
    void DisplayDeckCards()
    {
        foreach (Transform child in deckPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in playerDeck.deckCards)
        {
            GameObject cardButton = Instantiate(deckCardButtonPrefab, deckPanel);
            cardButton.GetComponentInChildren<TMP_Text>().text = card.cardName;
            //cardButton.GetComponent<Image>().sprite = card.cardImage;

            Button[] buttons = cardButton.GetComponentsInChildren<Button>();
            if (buttons.Length >= 2)
            {
                Button firstButton = buttons[0];  // 一番目のボタン
                Button secondButton = buttons[1]; // 二番目のボタン

                firstButton.onClick.AddListener(() => cardDetailPanel.ShowCardDetail(card));//Debug.Log("カード詳細"));
                secondButton.onClick.AddListener(() => OnCardClicked(card, false));
            }
            //button.onClick.AddListener(() => OnCardClicked(card, false));
        }
    }

    //デッキ内のカードを一覧で表示
    void DetailDeckCards()
    {
        foreach (Transform child in deckDetailPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in playerDeck.deckCards)
        {
            GameObject cardButton = Instantiate(deckDetailCardButtonPrefab, deckDetailPanel);
            cardButton.GetComponentInChildren<TMP_Text>().text = card.cardName;
            //cardButton.GetComponent<Image>().sprite = card.cardImage;

            Button button = cardButton.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => cardDetailPanel.ShowCardDetail(card));//Debug.Log("カード詳細"));
        }
    }

    // カードがクリックされたときの処理
    void OnCardClicked(Card clickedCard, bool isAdding)
    {
        if (isAdding)
        {
            playerDeck.deckCards.Add(clickedCard);
            allCards.Remove(clickedCard);
            DisplayDeckCards();
            DisplayAllCards();
            DetailDeckCards();
        }
        else
        {
            playerDeck.deckCards.Remove(clickedCard);
            allCards.Add(clickedCard);
            DisplayDeckCards();
            DisplayAllCards();
            DetailDeckCards();
        }

        SaveDeck();
    }
}
