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
    //会話内容保持スクリプト
    [SerializeField]
    private Conversation conversation = null;
    //　キャラクターのTransform
    private Transform conversationPartnerTransform;
    //　村人がキャラクターの方向に回転するスピード
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
            //　村人がキャラクターの方向をある程度向くまで回転させる
            if (Vector3.Angle(transform.forward, new Vector3(conversationPartnerTransform.position.x, transform.position.y, conversationPartnerTransform.position.z) - transform.position) > 5f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(conversationPartnerTransform.position.x, transform.position.y, conversationPartnerTransform.position.z) - transform.position), rotationSpeed * Time.deltaTime);
                this.conversationPartnerTransform = conversationPartnerTransform;
            }
        }
    }

    //　Conversionスクリプトを返す
    public Conversation GetConversation()
    {
        return conversation;
    }
}
