using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckButton : MonoBehaviour
{
    [Header("押したときに表示させたいパネル")]
    [SerializeField] GameObject subjectPanel;
    [SerializeField] GameObject blackPanel;
    FadePanelControl blackPanelControl;
    const float blackPanelSpeed = 0.5f;

    void Start()
    {
        blackPanelControl = blackPanel.GetComponent<FadePanelControl>();

    }

    public void OnBuckClick()
    {
        blackPanel.SetActive(true);
        blackPanelControl.FadeOut(blackPanelSpeed);
        gameObject.transform.parent.gameObject.SetActive(false);
        subjectPanel.SetActive(true);
        blackPanelControl.FadeIn(blackPanelSpeed);
        blackPanel.SetActive(false);
    }
}
