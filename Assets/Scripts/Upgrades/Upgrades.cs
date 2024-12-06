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
    public static float lessGarbage = 2.0f;
    public static int lessGarbageCounter;

    // Delivery Upgrades
    public static int increaseShootingSpeed = 1;
    public static int increaseShootingSpeedCounter;
    public static int moreHealth = 1;
    public static int moreHealthCounter;
    public static int addLasers;
    public static int addLasersCounter;

    // Route Upgrades
    public static int moreMoneyPP = 1; // more $ per package
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
    public TextMeshProUGUI addLasersText;

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
            handLimitCostText.text = "$" + handLimitCost.ToString();
        }

        lessGarbageUpgradeBar.sprite = upgradeSprites[lessGarbageCounter];
        if (lessGarbageCounter == upgradeSprites.Length - 1)
        {
            lessGarbageCostText.text = "Max";
        }
        else
        {
            lessGarbageCostText.text = "$" + lessGarbageCost.ToString();
        }

        increaseShootingSpeedUpgradeBar.sprite = upgradeSprites[increaseShootingSpeedCounter];
        if (increaseShootingSpeedCounter == upgradeSprites.Length - 1)
        {
            increaseShootingSpeedCostText.text = "Max";
        }
        else
        {
            increaseShootingSpeedCostText.text = "$" + increaseShootingSpeedCost.ToString();
        }

        moreHealthUpgradeBar.sprite = upgradeSprites[moreHealthCounter];
        if (moreHealthCounter == upgradeSprites.Length - 1)
        {
            moreHealthCostText.text = "Max";
        }
        else
        {
            moreHealthCostText.text = "$" + moreHealthCost.ToString();
        }

        addLasersUpgradeBar.sprite = upgradeSprites[addLasersCounter];
        if (addLasersCounter == upgradeSprites.Length - 1)
        {
            addLasersCostText.text = "Max";
        }
        else
        {
            addLasersCostText.text = "$" + addLasersCost.ToString();
        }

        moreMoneyPPUpgradeBar.sprite = upgradeSprites[moreMoneyPPCounter];
        if (moreMoneyPPCounter == upgradeSprites.Length - 1)
        {
            moreMoneyPPCostText.text = "Max";
        }
        else
        {
            moreMoneyPPCostText.text = "$" + moreMoneyPPCost.ToString();
        }

        morePackagesDeliveredUpgradeBar.sprite = upgradeSprites[morePackagesDeliveredCounter];
        if (morePackagesDeliveredCounter == upgradeSprites.Length - 1)
        {
            morePackagesDeliveredCostText.text = "Max";
        }
        else
        {
            morePackagesDeliveredCostText.text = "$" + morePackagesDeliveredCost.ToString();
        }

        researchUpgradeBar.sprite = upgradeSprites[researchCounter];
        if (researchCounter == upgradeSprites.Length - 1)
        {
            researchCostText.text = "Max";
        }
        else
        {
            researchCostText.text = "$" + researchCost.ToString();
        }
        if (addLasersCounter > 1)
        {
            addLasersText.text = "Increase laser shooting speed";
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
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyLessGarbageUpgrade()
    {
        if (Currency.money >= lessGarbageCost && lessGarbageCounter < upgradeSprites.Length - 1 && lessGarbage > 0)
        {
            Currency.money -= lessGarbageCost;
            lessGarbageCost *= 2;
            lessGarbageCounter++;
            lessGarbage -= 0.4f;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyIncreaseShootingSpeedUpgrade()
    {
        if (Currency.money >= increaseShootingSpeedCost && increaseShootingSpeedCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= increaseShootingSpeedCost;
            increaseShootingSpeedCost *= 2;
            increaseShootingSpeedCounter++;
            increaseShootingSpeed++;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
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
            moreHealth++;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
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
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyMoreMoneyPPUpgrade()
    {
        if (Currency.money >= moreMoneyPPCost && moreMoneyPPCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= moreMoneyPPCost;
            moreMoneyPPCost *= 2;
            moreMoneyPPCounter++;
            // MoreMoneyPP is used as a small multiplier. 
            moreMoneyPP++;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
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
            SoundManager.Instance.PlaySound2D("Cha ching");
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
                researchCounter++;
                researchCost *= 2;
                print("planet unlocked");
                // change research value
                UpdateUI();
                SoundManager.Instance.PlaySound2D("Success");
                print("1");
            }
            else
            {
                print("0");
                researchTries++;
                if (researchTries < 3)
                {
                    SoundManager.Instance.PlaySound2D("Lose");
                }
            }
            // 3 failed tries = 1 success
            if (researchTries == 3)
            {
                researchTries = 0;
                researchCounter++;
                researchCost *= 2;
                print("planet unlocked");
                // change research value
                UpdateUI();
                SoundManager.Instance.PlaySound2D("Success");
            }
        }
    }

    public void GoToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}