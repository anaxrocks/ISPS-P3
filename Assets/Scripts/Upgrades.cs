using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Upgrades : MonoBehaviour
{
    // Money counter top left
    public TextMeshProUGUI moneyText;

    /* Any upgrades with counter at the end means it is num of upgrades
     * purchased. Use the normal variable name without counter for updating values
     */

    // Sorting Upgrades
    public static int handLimit = 1;
    public static int handLimitCounter;
    public static int lessGarbage = 5;
    public static int lessGarbageCounter;

    // Delivery Upgrades
    public static int increaseShootingSpeed = 1;
    public static int increaseShootingSpeedCounter;
    public static int moreHealth = 3;
    public static int moreHealthCounter;
    public static int addLasers;
    public static int addLasersCounter;

    // Route Upgrades
    public static int moreMoneyPP; // more $ per package
    public static int moreMoneyPPCounter;
    public static int morePackagesDelivered;
    public static int morePackagesDeliveredCounter;

    // Research upgrade
    public static int research; // might not need this, use researchCounter instead?
    public static int researchCounter;
    public static int researchTries;
    public static int researchPieces;

    // UI References
    public Image handLimitUpgradeBar;
    public Image lessGarbageUpgradeBar;
    public Image increaseShootingSpeedUpgradeBar;
    public Image moreHealthUpgradeBar;
    public Image addLasersUpgradeBar;
    public Image moreMoneyPPUpgradeBar;
    public Image morePackagesDeliveredUpgradeBar;
    public Image researchUpgradeBar;
    public Sprite[] upgradeSprites; // Drag upgrade sprites in ascending order

    // Costs for upgrades
    public static int handLimitCost = 5;
    public TextMeshProUGUI handLimitCostText;
    public static int lessGarbageCost = 5;
    public TextMeshProUGUI lessGarbageCostText;
    public static int increaseShootingSpeedCost = 5;
    public TextMeshProUGUI increaseShootingSpeedCostText;
    public static int moreHealthCost = 5;
    public TextMeshProUGUI moreHealthCostText;
    public static int addLasersCost = 5;
    public TextMeshProUGUI addLasersCostText;
    public static int moreMoneyPPCost = 5;
    public TextMeshProUGUI moreMoneyPPCostText;
    public static int morePackagesDeliveredCost = 5;
    public TextMeshProUGUI morePackagesDeliveredCostText;
    public static int researchCost = 5;
    public TextMeshProUGUI researchCostText;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = "$" + Currency.money.ToString();

        // Update upgrade bar sprites
        handLimitUpgradeBar.sprite = upgradeSprites[handLimitCounter];
        if (handLimitCounter == upgradeSprites.Length - 1)
        {
            handLimitCostText.text = "Max";
        } else
        {
            handLimitCostText.text = "Buy $" + handLimitCost.ToString();
        }

        lessGarbageUpgradeBar.sprite = upgradeSprites[lessGarbageCounter];
        if (lessGarbageCounter == upgradeSprites.Length - 1)
        {
            lessGarbageCostText.text = "Max";
        }
        else
        {
            lessGarbageCostText.text = "Buy $" + lessGarbageCost.ToString();
        }

        increaseShootingSpeedUpgradeBar.sprite = upgradeSprites[increaseShootingSpeedCounter];
        if (increaseShootingSpeedCounter == upgradeSprites.Length - 1)
        {
            increaseShootingSpeedCostText.text = "Max";
        }
        else
        {
            increaseShootingSpeedCostText.text = "Buy $" + increaseShootingSpeedCost.ToString();
        }

        moreHealthUpgradeBar.sprite = upgradeSprites[moreHealthCounter];
        if (moreHealthCounter == upgradeSprites.Length - 1)
        {
            moreHealthCostText.text = "Max";
        }
        else
        {
            moreHealthCostText.text = "Buy $" + moreHealthCost.ToString();
        }

        addLasersUpgradeBar.sprite = upgradeSprites[addLasersCounter];
        if (addLasersCounter == upgradeSprites.Length - 1)
        {
            addLasersCostText.text = "Max";
        }
        else
        {
            addLasersCostText.text = "Buy $" + addLasersCost.ToString();
        }

        moreMoneyPPUpgradeBar.sprite = upgradeSprites[moreMoneyPPCounter];
        if (moreMoneyPPCounter == upgradeSprites.Length - 1)
        {
            moreMoneyPPCostText.text = "Max";
        }
        else
        {
            moreMoneyPPCostText.text = "Buy $" + moreMoneyPPCost.ToString();
        }

        morePackagesDeliveredUpgradeBar.sprite = upgradeSprites[morePackagesDeliveredCounter];
        if (morePackagesDeliveredCounter == upgradeSprites.Length - 1)
        {
            morePackagesDeliveredCostText.text = "Max";
        }
        else
        {
            morePackagesDeliveredCostText.text = "Buy $" + morePackagesDeliveredCost.ToString();
        }

        researchUpgradeBar.sprite = upgradeSprites[researchCounter];
        if (researchCounter == upgradeSprites.Length - 1)
        {
            researchCostText.text = "Max";
        }
        else
        {
            researchCostText.text = "Buy $" + researchCost.ToString();
        }
    }

    public void BuyHandLimitUpgrade()
    {
        if (Currency.money >= handLimitCost && handLimitCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= handLimitCost;
            handLimitCost *= 2;
            handLimitCounter++;
            handLimit++;
            UpdateUI();
        }
    }

    public void BuyLessGarbageUpgrade()
    {
        if (Currency.money >= lessGarbageCost && lessGarbageCounter < upgradeSprites.Length - 1 && lessGarbage > 0)
        {
            Currency.money -= lessGarbageCost;
            lessGarbageCost *= 2;
            lessGarbageCounter++;
            lessGarbage--;
            // Change lessGarbage value
            UpdateUI();
        }
    }

    public void BuyIncreaseShootingSpeedUpgrade()
    {
        if (Currency.money >= increaseShootingSpeedCost && increaseShootingSpeedCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= increaseShootingSpeedCost;
            increaseShootingSpeedCost *= 2;
            increaseShootingSpeedCounter++;
            // Change increaseShootingSpeed value
            UpdateUI();
        }
    }

    public void BuyMoreHealthUpgrade()
    {
        if (Currency.money >= moreHealthCost && moreHealthCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= moreHealthCost;
            moreHealthCost *= 2;
            moreHealthCounter++;
            // Change moreHealth value
            UpdateUI();
        }
    }

    public void BuyAddLasersUpgrade()
    {
        if (Currency.money >= addLasersCost && addLasersCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= addLasersCost;
            addLasersCost *= 2;
            addLasersCounter++;
            // Change addlasers value
            UpdateUI();
        }
    }

    public void BuyMoreMoneyPPUpgrade()
    {
        if (Currency.money >= moreMoneyPPCost && moreMoneyPPCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= moreMoneyPPCost;
            moreMoneyPPCost *= 2;
            moreMoneyPPCounter++;
            // Change moremnoneypp value
            UpdateUI();
        }
    }

    public void BuyMorePackagesDeliveredUpgrade()
    {
        if (Currency.money >= morePackagesDeliveredCost && morePackagesDeliveredCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= morePackagesDeliveredCost;
            morePackagesDeliveredCost *= 2;
            morePackagesDeliveredCounter++;
            // Change morepackagesdelivered value
            UpdateUI();
        }
    }

    public void BuyResearchUpgrade()
    {
        if (Currency.money >= researchCost && researchCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= researchCost;
            UpdateUI();

            // 50/50 chance to unlock piece of planet
            if (Random.Range(0, 2) == 1)
            {
                researchTries = 0;
                researchPieces++;
                print("1");
            } else
            {
                print("0");
                researchTries++;
            }

            // 3 failed tries = 1 success
            if (researchTries == 3)
            {
                researchTries = 0;
                researchPieces++; // probably update UI to indicate pieces +1
            }

            // 3 pieces = planet unlocked
            if (researchPieces == 3)
            {
                researchTries = 0;
                researchPieces = 0;
                researchCounter++;
                researchCost *= 2;
                print("planet unlocked");
                // change research value
                UpdateUI();
            }
        }
    }

    public void GoToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}