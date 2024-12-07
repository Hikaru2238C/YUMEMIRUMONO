using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text mainText; // UIのMainTextをアタッチ
    [SerializeField] TMP_Text nameText; // UIのNameTextをアタッチ
    [SerializeField] FadePanelControl blackPanelControl; //BlackPanelをアタッチ
    [SerializeField] FadePanelControl whitePanelControl; //WhitePanelをアタッチ
    [SerializeField] AudioSource BGM;
    AudioClip BGMClip;
    [SerializeField] AudioSource SE;
    AudioClip SEClip;
    [SerializeField] Image backGroundPanel;
    [SerializeField] Image charaImage;
    [SerializeField] ShakeScreen shakeScreen;
    [SerializeField] BGMDataBase bgmDataBase;
    [SerializeField] BackgroundDataBase backgroundDataBase;
    [SerializeField] PortraitDataBase portraitDataBase;
    [SerializeField] SEDataBase seDataBase;

    float delaySpeed; // 次の文字を表示するまでの時間[s]
    private Coroutine showCoroutine;

    //名前テキストの変更
    public void UpdateNameText(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            nameText.text = text;
        }
        else
        {
            nameText.text = ""; // 空の場合はテキストをクリア
        }
    }

    //会話テキストの変更
    public void UpdateMainText(string text,float speed)
    {
        if (!string.IsNullOrEmpty(text))
        {
            delaySpeed = speed;
            mainText.text = text;
            Show();
        }
        else
        {
            mainText.text = ""; // 空の場合はテキストをクリア
        }
    }

    //会話テキストのクリア
    public void ClearDialogue()
    {
        mainText.text = ""; // 明示的にテキストを消す
    }
    // 文字送り演出を表示する
    public void Show()
    {
        if (mainText.text == null) { return; }
        // 前回の演出処理が走っていたら、停止
        if (showCoroutine != null)
        {
            StopCoroutine(showCoroutine);
        }
        // １文字ずつ表示する演出のコルーチンを実行する
        showCoroutine = StartCoroutine(ShowCoroutine());
    }

    // １文字ずつ表示する演出のコルーチン
    private IEnumerator ShowCoroutine()
    {
        // 待機用コルーチン
        // GC Allocを最小化するためキャッシュしておく
        var delay = new WaitForSeconds(delaySpeed);

        // テキスト全体の長さ
        var length = mainText.text.Length;

        // １文字ずつ表示する演出
        for (var i = 0; i < length; i++)
        {
            // 徐々に表示文字数を増やしていく
            mainText.maxVisibleCharacters = i;

            // 一定時間待機
            yield return delay;
        }

        // 演出が終わったら全ての文字を表示する
        mainText.maxVisibleCharacters = length;

        showCoroutine = null;
    }

    //画面を素→黒
    public void UpdateBlackOut(float speed)
    {
        blackPanelControl.FadeOut(speed);
    }

    //画面を黒→素
    public void UpdateBlackIn(float speed)
    {
        blackPanelControl.FadeIn(speed);
    }

    //画面を素→白
    public void UpdateWhiteOut(float speed)
    {
        whitePanelControl.FadeOut(speed);
    }

    //画面を白→素
    public void UpdateWhiteIn(float speed)
    {
        whitePanelControl.FadeIn(speed);
    }

    //BGMを変える
    public void UpdateBGM(string songName)
    {
        //BGMClip = (AudioClip)Resources.Load("BGM/" + songName);
        Dictionary<string, AudioClip> dict = bgmDataBase.BGMData.ToDictionary();

        foreach (var kvp in dict)
        {
            if (kvp.Key == songName)
            {
                BGMClip = kvp.Value;
            }
        }
        BGM.PlayOneShot(BGMClip);
    }

    //SEを鳴らす
    public void UpdateSE(string seName)
    {
        //SEClip = (AudioClip)Resources.Load("SE/" + seName);
        Dictionary<string, AudioClip> dict = seDataBase.SEData.ToDictionary();

        foreach (var kvp in dict)
        {
            if (kvp.Key == seName)
            {
                SEClip = kvp.Value;
            }
        }
        SE.PlayOneShot(SEClip);
    }

    //画面を揺らす
    public void UpdateScreenShake(float power)
    {
        shakeScreen.StartShake(power);
    }

    //キャラクターを変える
    public void UpdatePortrait(string charaImageName)
    {
        //charaImage.sprite = (Sprite)Resources.Load("charaImage/" + charaImageName, typeof(Sprite));
        Dictionary<string, Sprite> dict = portraitDataBase.PortraitData.ToDictionary();

        foreach (var kvp in dict)
        {
            if (kvp.Key == charaImageName)
            {
                charaImage.sprite = kvp.Value;
            }
        }
        if (charaImage.sprite == null)
        {
            charaImage.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else
        {
            charaImage.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    //背景を変える
    public void UpdateBackground(string backImageName)
    {
        //backGroundPanel.sprite = (Sprite)Resources.Load("BackGroundImage/" + backImageName, typeof(Sprite));
        Dictionary<string, Sprite> dict = backgroundDataBase.BackgroundData.ToDictionary();

        foreach (var kvp in dict)
        {
            if (kvp.Key == backImageName)
            {
                backGroundPanel.sprite = kvp.Value;
            }
        }
    }
}
