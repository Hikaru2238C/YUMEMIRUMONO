using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField] GameObject subjectPanel;
    [SerializeField] CanvasManager canvasManager;
    [SerializeField] FadePanelControl blackPanel;
    const float blackPanelSpeed = 0.5f;

    public void OnStartButton()
    {
        blackPanel.FadeOut(blackPanelSpeed);
        SceneManager.LoadScene("MainTown");
    }

    public void OnDeleteSaveDataButton()
    {
        blackPanel.FadeOut(blackPanelSpeed);
        canvasManager.PanelChange(blackPanelSpeed, transform.parent.gameObject, subjectPanel);
    }

    public void OnPrecautionsButton()
    {
        blackPanel.FadeOut(blackPanelSpeed);
        canvasManager.PanelChange(blackPanelSpeed, transform.parent.gameObject, subjectPanel);
    }
}
