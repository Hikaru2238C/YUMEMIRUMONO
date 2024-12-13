using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSelectManager : MonoBehaviour
{
    [SerializeField] GetButtonID getButtonID;
    [SerializeField] GateIDData gateIDData;
    public void LaunchQuest()
    {
        Debug.Log(getButtonID.ID);
        gateIDData.questID = getButtonID.ID;
        if (getButtonID.ID.StartsWith("バトル"))
        {
            SceneManager.LoadScene("Battle");
        }
        else
        {
            SceneManager.LoadScene("Story");
        }
    }
}
