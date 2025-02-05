using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject blackPanel;
    GameObject nextPanel;
    GameObject nowPanel;
    FadePanelControl fadePanelControl;
    bool onChangePanel;
    float changeWaitTime;
    float changeWaitTimer;
    void Start()
    {
        fadePanelControl = blackPanel.GetComponent<FadePanelControl>();
    }

    void Update()
    {
        if( onChangePanel)
        {
            changeWaitTimer += Time.deltaTime;
            if( changeWaitTimer > changeWaitTime)
            {
                Debug.Log("明転");
                nowPanel.SetActive(false);
                nextPanel.SetActive(true);
                fadePanelControl.FadeIn(changeWaitTime);
                onChangePanel = false;
            }
        }
        if (!onChangePanel)
        {
            changeWaitTimer = 0;
        }
    }

    public void PanelChange(float time,GameObject nowPanelT,GameObject nextPanelT)
    {
        nowPanel = nowPanelT;
        nextPanel = nextPanelT;
        changeWaitTime = time;
        onChangePanel = true;
    }
}
