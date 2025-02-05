using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] GameObject buyPanel;
    [SerializeField] GameObject sellPanel;

    public void OnBuyClick()
    {
        buyPanel.SetActive(true);
    }
    public void OnSellClick()
    {
        sellPanel.SetActive(true);
    }
}
