using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerScript : MonoBehaviour
{
    public enum State
    {
        Wait,
        Walk,
        Talk
    }
    
    private State state;
    //��b���e�ێ��X�N���v�g
    [SerializeField]
    private Conversation conversation = null;
    //�@�L�����N�^�[��Transform
    private Transform conversationPartnerTransform;
    //�@���l���L�����N�^�[�̕����ɉ�]����X�s�[�h
    [SerializeField]
    private float rotationSpeed = 2f;

    public void SetState(State state, Transform conversationPartnerTransform = null)
    {
        this.state = state;
        if (state == State.Wait)
        {
        }
        else if (state == State.Walk)
        {
        }
        else if (state == State.Talk)
        {
            //�@���l���L�����N�^�[�̕�����������x�����܂ŉ�]������
            if (Vector3.Angle(transform.forward, new Vector3(conversationPartnerTransform.position.x, transform.position.y, conversationPartnerTransform.position.z) - transform.position) > 5f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(conversationPartnerTransform.position.x, transform.position.y, conversationPartnerTransform.position.z) - transform.position), rotationSpeed * Time.deltaTime);
                this.conversationPartnerTransform = conversationPartnerTransform;
            }
        }
    }

    //�@Conversion�X�N���v�g��Ԃ�
    public Conversation GetConversation()
    {
        return conversation;
    }
}
