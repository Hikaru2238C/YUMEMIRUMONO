using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ActiveMessagePanel : MonoBehaviour
{
    //�@MessageUI�ɐݒ肳��Ă���Message�X�N���v�g��ݒ�
    [SerializeField]
    private MessageScript messageScript;

    //�@�\�������郁�b�Z�[�W
    private string message = "��������������������������������������������������������������������������������������������������������������������������������������������"
                             + "��������������������������������������������������������������������������������������������������������������\n"
                             + "����������\n"
                             + "������������������������";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //messageScript.SetMessagePanel(message);
        }
    }
}
