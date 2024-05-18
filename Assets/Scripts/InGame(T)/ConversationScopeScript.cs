using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationScopeScript : MonoBehaviour
{
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player"
            && col.GetComponent<BasicBehaviour>().GetState() != BasicBehaviour.State.Talk
            )
        {
            //�@�L�����N�^�[���߂Â������b����Ƃ��Ď����̃Q�[���I�u�W�F�N�g��n��
            col.GetComponent<MessageScript>().SetConversationPartner(transform.parent.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player"
            && col.GetComponent<BasicBehaviour>().GetState() != BasicBehaviour.State.Talk
            )
        {
            //�@�L�����N�^�[���������������b���肩��O��
            col.GetComponent<MessageScript>().ResetConversationPartner(transform.parent.gameObject);
        }
    }
}
