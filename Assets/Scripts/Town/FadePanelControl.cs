using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanelControl : MonoBehaviour
{
    float alpha = 0.0f;//���ߗ��A�����ω�������
    float fadeSpeed;//�t�F�[�h�Ɋ|���鎞��
    bool isFadeIn = false;
    bool isFadeOut = false;
    private void Update()
    {
        if (isFadeIn)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            if (alpha <= 0.0f)//�����ɂȂ�����A�t�F�[�h�C�����I��
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (isFadeOut)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 1.0f)//�^�����ɂȂ�����A�t�F�[�h�A�E�g���I��
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    //��(��)����f
    public void FadeIn(float speed)
    {
        isFadeIn = true;
        fadeSpeed = speed;
    }
    //�f���獕(��)
    public void FadeOut(float speed)
    {
        isFadeOut = true;
        fadeSpeed = speed;
    }
}
