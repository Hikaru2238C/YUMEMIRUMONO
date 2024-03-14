using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkSystem : MonoBehaviour
{
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {

        }
    }
    //ブランチ用コメント
}
