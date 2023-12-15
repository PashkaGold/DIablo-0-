using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetherihgCounter : MonoBehaviour
{
    private int wood = 0;
    private int stone = 0;
    private int mob = 0;

    public TMP_Text woodText;
    public TMP_Text stoneText;
    public TMP_Text mobText;

    private void Awake()
    {
        woodText.text = PlayerPrefs.GetInt("wood").ToString();
        stoneText.text = PlayerPrefs.GetInt("stone").ToString();
        mobText.text = PlayerPrefs.GetInt("mob").ToString();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Tree Gathering")
        {
            wood++;
            PlayerPrefs.SetInt("wood", wood);
            woodText.text = wood.ToString();
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Stone Gathering")
        {
            stone++;
            PlayerPrefs.SetInt("stone", stone);
            stoneText.text = stone.ToString();
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "Mob Gathering")
        {
            mob++;
            PlayerPrefs.SetInt("mob", mob);
            mobText.text = mob.ToString();
            Destroy(coll.gameObject);
        }
    }
}
