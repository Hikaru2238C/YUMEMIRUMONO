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
            //　キャラクターが近づいたら会話相手として自分のゲームオブジェクトを渡す
            col.GetComponent<MessageScript>().SetConversationPartner(transform.parent.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player"
            && col.GetComponent<BasicBehaviour>().GetState() != BasicBehaviour.State.Talk
            )
        {
            //　キャラクターが遠ざかったら会話相手から外す
            col.GetComponent<MessageScript>().ResetConversationPartner(transform.parent.gameObject);
        }
    }
}
