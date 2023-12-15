using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bonuscoin : MonoBehaviour
{
    public string bonusName;
    public TMP_Text coinCount;

    private void Awake()
    {
        coinCount.text = PlayerPrefs.GetInt("Tree").ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (bonusName)
            {
                case "coin":
                    int coins = PlayerPrefs.GetInt("coins");
                    PlayerPrefs.SetInt("coins", coins + 1);
                    coinCount.text = (coins + 1).ToString();
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
