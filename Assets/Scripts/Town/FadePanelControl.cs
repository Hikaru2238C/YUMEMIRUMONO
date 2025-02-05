using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanelControl : MonoBehaviour
{
    float alpha = 0.0f;//透過率、これを変化させる
    float fadeSpeed;//フェードに掛かる時間
    bool isFadeIn = false;
    bool isFadeOut = false;
    private void Update()
    {
        if (isFadeIn)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            if (alpha <= 0.07f)//透明になったら、フェードインを終了
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (isFadeOut)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 0.93f)//真っ黒になったら、フェードアウトを終了
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    //黒(白)から素
    public void FadeIn(float speed)
    {
        isFadeIn = true;
        fadeSpeed = speed;
    }
    //素から黒(白)
    public void FadeOut(float speed)
    {
        isFadeOut = true;
        fadeSpeed = speed;
    }
}
