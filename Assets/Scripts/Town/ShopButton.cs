using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] GameObject buyPanel;
    [SerializeField] GameObject sellPanel;
    void Start()
    {
        
    }


    void OnBuyClick()
    {
        buyPanel.SetActive(true);
    }
    void OnSellClick()
    {
        sellPanel.SetActive(false);
    }
    void OnbackShopClick()
    {
        buyPanel.SetActive(false);
        sellPanel.SetActive(false);
    }
}
