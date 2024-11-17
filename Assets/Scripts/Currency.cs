using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public static int money = 0;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyText();
    }

    public void AddMoney()
    {
        money += 10;
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
