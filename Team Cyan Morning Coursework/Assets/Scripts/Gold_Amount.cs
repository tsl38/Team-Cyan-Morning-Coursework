using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold_Amount : MonoBehaviour
{
    public int goldAmount;
    public TextMeshProUGUI goldAmountText;


    public void AddGold(int amount) {
        goldAmount = goldAmount + amount;
        goldAmountText.text = goldAmount.ToString();
    }

    public void RemoveGold(int amount) {
        if (amount < goldAmount) {
            goldAmount = goldAmount - amount;
            goldAmountText.text = goldAmount.ToString();
        }
    }
}
