using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckButton : MonoBehaviour
{
    [SerializeField] GameObject beforePanel;
    [SerializeField] GameObject blackPanel;
    FadePanelControl blackPanelControl;
    const float blackPanelSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        blackPanelControl = blackPanel.GetComponent<FadePanelControl>();

    }

    public void OnBuckClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        blackPanelControl.FadeOut(blackPanelSpeed);
        beforePanel.SetActive(true);
    }
}
