using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public static int money;
    public static int repHome = 3;
    public static int rep1;
    public static int rep2;
    public static int rep3;
    public static int rep4;
    public TextMeshProUGUI moneyText;

    // minigame variables
    public static int pGoal; // num packages needed
    public static float pSortTimer = 30; // time left for sorting minigame
    public static int pSorted; // sorting minigame
    public static int pMiss; // mis-sorted packages
    public static float pDeliveryTimer = 30; // time left for sorting minigame
    public static int pDelivered; // delivery minigame

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        UpdateMoneyText();
    }

    public void GetMoney()
    {
        UpdateMoneyText();
    }

    // Updates the money display in the UI
    public void UpdateMoneyText()
    {
        moneyText.text = "$" + money.ToString();
    }
}
