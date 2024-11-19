using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    // Sorting Upgrades
    public static int handLimit;
    public static int lessGarbage;

    // Delivery Upgrades
    public static int increaseShootingSpeed;
    public static int moreShields;
    public static int addLasers;

    // Route Upgrades
    public static int moreMoneyPP; // more $ per package
    public static int morePackagesDelivered;
    public static int research;

    // UI References
    public Image handLimitUpgradeBar;
    public Image lessGarbageUpgradeBar;
    public Sprite[] upgradeSprites; // Drag upgrade sprites in ascending order

    // Costs for upgrades
    public int handLimitCost = 1;
    public TextMeshProUGUI handLimitText;
    public int lessGarbageCost = 1;
    public TextMeshProUGUI lessGarbageCostText;

    void Start()
    {
        Currency.money = 10;
        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = "$" + Currency.money.ToString();
        // Update upgrade bar sprites
        handLimitUpgradeBar.sprite = upgradeSprites[handLimit];
        handLimitText.text = "Buy $" + handLimitCost.ToString();
        lessGarbageUpgradeBar.sprite = upgradeSprites[lessGarbage];
        lessGarbageCostText.text = "Buy $" + lessGarbageCost.ToString();
    }

    public void BuyHandLimitUpgrade()
    {
        if (Currency.money >= handLimitCost && handLimit < upgradeSprites.Length - 1)
        {
            Currency.money -= handLimitCost;
            handLimit++;
            UpdateUI();
            print(handLimit);
        }
    }

    public void BuyLessGarbageUpgrade()
    {
        if (Currency.money >= lessGarbageCost && lessGarbage < upgradeSprites.Length - 1)
        {
            Currency.money -= lessGarbageCost;
            lessGarbage++;
            UpdateUI();
            print(lessGarbage);
        }
    }

    public void GoToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}
