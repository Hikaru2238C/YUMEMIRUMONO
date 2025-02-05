using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckButton : MonoBehaviour
{
    [Header("押したときに表示させたいパネル")]
    [SerializeField] GameObject subjectPanel;
    [SerializeField] GameObject blackPanel;
    [SerializeField] CanvasManager canvasManager;
    GameObject parentPanel;
    FadePanelControl blackPanelControl;
    const float blackPanelSpeed = 0.5f;

    void Start()
    {
        blackPanelControl = blackPanel.GetComponent<FadePanelControl>();
        parentPanel = transform.parent.gameObject;

    }

    public void OnBuckClick()
    {
        blackPanelControl.FadeOut(blackPanelSpeed);
        canvasManager.PanelChange(blackPanelSpeed,parentPanel,subjectPanel);
    }

    public void OnQuicBackClick()
    {
        transform.parent.gameObject.SetActive(false);
        subjectPanel.SetActive(true);
    }
}
