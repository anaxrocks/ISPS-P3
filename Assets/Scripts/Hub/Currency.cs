using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public static int money;
    public static int repHome;
    public static int rep1;
    public static int rep2;
    public static int rep3;
    public static int rep4;
    public TextMeshProUGUI moneyText;

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
    private void UpdateMoneyText()
    {
        moneyText.text = "$" + money.ToString();
    }
}