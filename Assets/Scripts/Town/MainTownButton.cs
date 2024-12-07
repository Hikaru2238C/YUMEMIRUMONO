using UnityEngine;

public class MainTownButton : MonoBehaviour
{
    [SerializeField] GameObject homePanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject hotelPanel;
    [SerializeField] GameObject organizationPanel;
    [SerializeField] GameObject gatePanel;
    [SerializeField] GameObject blackPanel;
    FadePanelControl blackPanelControl;
    const float blackPanelSpeed = 2;
    //bool blackIn;
    void Start()
    {
        blackPanelControl = blackPanel.GetComponent<FadePanelControl>();
        //blackIn = false;
    }

    public void OnMainShopClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        blackPanelControl.FadeOut(blackPanelSpeed);
        shopPanel.SetActive(true);
    }
    public void OnMainHotelClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        blackPanelControl.FadeOut(blackPanelSpeed);
        hotelPanel.SetActive(true);
    }

    public void OnMainOrganizationClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        blackPanelControl.FadeOut(blackPanelSpeed);
        organizationPanel.SetActive(true);
    }

    public void OnMainGateClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        blackPanelControl.FadeOut(blackPanelSpeed);
        gatePanel.SetActive(true);
    }
}
