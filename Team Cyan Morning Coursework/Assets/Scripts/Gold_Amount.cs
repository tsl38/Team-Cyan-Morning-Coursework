using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold_Amount : MonoBehaviour
{
    private int goldAmount;
    public TextMeshProUGUI goldAmountText;


    public void addGold(int amount) {
        goldAmount = goldAmount + amount;
        goldAmountText.text = goldAmount.ToString();
    }

    public void removeGold(int amount) {
        if (amount < goldAmount) {
            goldAmount = goldAmount - amount;
            goldAmountText.text = goldAmount.ToString();
        }
    }
}
