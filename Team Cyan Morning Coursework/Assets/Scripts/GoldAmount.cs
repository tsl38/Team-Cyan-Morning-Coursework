using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldAmount : MonoBehaviour
{
    public int goldAmount;
    public TextMeshProUGUI goldAmountText;

    public void Awake() {
        //Sets initial value of the gold.
        if (GameManager.Instance.goldAmount >= 0) {
            goldAmountText.text = GameManager.Instance.goldAmount.ToString();
        }
    }

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
