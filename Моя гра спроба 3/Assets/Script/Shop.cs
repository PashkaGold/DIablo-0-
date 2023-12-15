using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    
    public int priceTree, access;
    public int priceStoon;
    public int priceMob;


    public TMP_Text obgectPrice;

    public string product;
    public Image[] emptyIcon;
    public Sprite filllcon;
    public int UpgradeLimit;

     void Awake()
    {
        PlayerPrefs.SetInt("coins", 1000);
        PlayerPrefs.SetInt("Stoon", 1000);
        PlayerPrefs.SetInt("Mob", 1000);
        iconsUpdate();
        AccessUpdate();
    }
    public void AccessUpdate()
    {
        access = PlayerPrefs.GetInt(product + "Access");
        obgectPrice.text = priceTree.ToString();
        obgectPrice.text = priceStoon.ToString();
        obgectPrice.text = priceMob.ToString();


        int count = PlayerPrefs.GetInt(product);
        if (count < UpgradeLimit)
        {
            count ++;
            PlayerPrefs.SetInt(product, count);
        }
        emptyIcon[count - 1 ].overrideSprite = filllcon;
        Debug.Log(count + 1);
    }
    public void OnButtonDown()
    {
        int coins = PlayerPrefs.GetInt("Tree");
        int coin = PlayerPrefs.GetInt("Stoon");
        int coi = PlayerPrefs.GetInt("Mob");
        if (access == 0)
        {
            if (coins >= priceTree)
            {
                PlayerPrefs.SetInt(product + "Access", 1);
                PlayerPrefs.SetInt("Tree", coins - priceTree);
                AccessUpdate();
            }
            if (coin >= priceStoon)
            {
                PlayerPrefs.SetInt(product + "Access", 1);
                PlayerPrefs.SetInt("Stoon", coin - priceStoon);
                AccessUpdate();
            }
            if (coi >= priceMob)
            {
                PlayerPrefs.SetInt(product + "Access", 1);
                PlayerPrefs.SetInt("Mob", coi - priceMob);
                AccessUpdate();
            }
        }
    }
        void iconsUpdate()
    {
        int count = PlayerPrefs.GetInt(product);
        for (int i = 0; i < count ; i++)
            {
            emptyIcon[i].overrideSprite = filllcon;
        }
    }
   
}
