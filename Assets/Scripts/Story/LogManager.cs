using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LogManager : MonoBehaviour
{
    [SerializeField] GameObject logPrefab_narative;
    [SerializeField] GameObject logPrefab_dialogue;
    [SerializeField] GameObject contentsObject;

    [SerializeField] ScrollRect scrollObject;

    List<GameObject> childs = new List<GameObject>();

    public void createLog(List<Log> logs)
    {
        foreach (Log log in logs)
        {
            if (log.getCharacterName() == null)
            {
                childs.Add(Instantiate(logPrefab_narative, contentsObject.transform));
                childs[childs.Count - 1].GetComponent<LogNarrativeUI>().setText(log.getDialogue());
            }
            else
            {
                childs.Add(Instantiate(logPrefab_dialogue, contentsObject.transform));
                childs[childs.Count - 1].GetComponent<LogDialogueUI>().setText(log.getCharacterName(), log.getDialogue());
            }
        }
        scrollObject.verticalNormalizedPosition = 0.0f;
    }
    public void CrearLogTexts()
    {
        foreach (GameObject child in childs)
        {
            Destroy(child.gameObject);
        }
        childs.Clear();
    }
}
