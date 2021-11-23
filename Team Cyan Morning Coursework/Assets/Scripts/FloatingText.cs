using UnityEngine;
using TMPro;


public class FloatingText : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    private void Start()
    {
        GetComponent<TypewriterEffect>().Run("The lady over there told me to go see you to get a potion of fire resistance\nThe lady over there told me to go see you to get a potion of fire resistance", textLabel);
    }
}
