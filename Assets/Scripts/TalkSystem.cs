using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSystem : MonoBehaviour
{
    [SerializeField] Text Text;
    [SerializeField] GameObject Panel;
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Panel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Panel.SetActive(false);
        }
    }
}
