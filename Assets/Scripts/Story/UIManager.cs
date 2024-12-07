using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text mainText; // UI��MainText���A�^�b�`
    [SerializeField] TMP_Text nameText; // UI��NameText���A�^�b�`
    [SerializeField] FadePanelControl blackPanelControl; //BlackPanel���A�^�b�`
    [SerializeField] FadePanelControl whitePanelControl; //WhitePanel���A�^�b�`
    [SerializeField] AudioSource BGM;
    AudioClip BGMClip;
    [SerializeField] AudioSource SE;
    AudioClip SEClip;
    [SerializeField] Image backGroundPanel;
    [SerializeField] Image charaImage;
    [SerializeField] ShakeScreen shakeScreen;

    float delaySpeed; // ���̕�����\������܂ł̎���[s]
    private Coroutine showCoroutine;

    //���O�e�L�X�g�̕ύX
    public void UpdateNameText(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            nameText.text = text;
        }
        else
        {
            nameText.text = ""; // ��̏ꍇ�̓e�L�X�g���N���A
        }
    }

    //��b�e�L�X�g�̕ύX
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
            mainText.text = ""; // ��̏ꍇ�̓e�L�X�g���N���A
        }
    }

    //��b�e�L�X�g�̃N���A
    public void ClearDialogue()
    {
        mainText.text = ""; // �����I�Ƀe�L�X�g������
    }
    // �������艉�o��\������
    public void Show()
    {
        if (mainText.text == null) { return; }
        // �O��̉��o�����������Ă�����A��~
        if (showCoroutine != null)
        {
            StopCoroutine(showCoroutine);
        }
        // �P�������\�����鉉�o�̃R���[�`�������s����
        showCoroutine = StartCoroutine(ShowCoroutine());
    }

    // �P�������\�����鉉�o�̃R���[�`��
    private IEnumerator ShowCoroutine()
    {
        // �ҋ@�p�R���[�`��
        // GC Alloc���ŏ������邽�߃L���b�V�����Ă���
        var delay = new WaitForSeconds(delaySpeed);

        // �e�L�X�g�S�̂̒���
        var length = mainText.text.Length;

        // �P�������\�����鉉�o
        for (var i = 0; i < length; i++)
        {
            // ���X�ɕ\���������𑝂₵�Ă���
            mainText.maxVisibleCharacters = i;

            // ��莞�ԑҋ@
            yield return delay;
        }

        // ���o���I�������S�Ă̕�����\������
        mainText.maxVisibleCharacters = length;

        showCoroutine = null;
    }

    //��ʂ�f����
    public void UpdateBlackOut(float speed)
    {
        blackPanelControl.FadeOut(speed);
    }

    //��ʂ������f
    public void UpdateBlackIn(float speed)
    {
        blackPanelControl.FadeIn(speed);
    }

    //��ʂ�f����
    public void UpdateWhiteOut(float speed)
    {
        whitePanelControl.FadeOut(speed);
    }

    //��ʂ𔒁��f
    public void UpdateWhiteIn(float speed)
    {
        whitePanelControl.FadeIn(speed);
    }

    //BGM��ς���
    public void UpdateBGM(string songName)
    {
        BGMClip = (AudioClip)Resources.Load("BGM/" + songName);
        BGM.PlayOneShot(BGMClip);
    }

    //SE��炷
    public void UpdateSE(string seName)
    {
        SEClip = (AudioClip)Resources.Load("SE/" + seName);
        SE.PlayOneShot(SEClip);
    }

    //��ʂ�h�炷
    public void UpdateScreenShake(float power)
    {
        shakeScreen.StartShake(power);
    }

    //�L�����N�^�[��ς���
    public void UpdatePortrait(string charaImageName)
    {
        charaImage.sprite = (Sprite)Resources.Load("charaImage/" + charaImageName, typeof(Sprite));
        if(charaImage.sprite == null)
        {
            charaImage.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else
        {
            charaImage.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    //�w�i��ς���
    public void UpdateBackground(string backImageName)
    {
        backGroundPanel.sprite = (Sprite)Resources.Load("BackGroundImage/" + backImageName, typeof(Sprite));
    }
}
