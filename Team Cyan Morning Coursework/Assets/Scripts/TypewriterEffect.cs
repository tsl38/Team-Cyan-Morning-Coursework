using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] public float typewriterSpeed;     // Set speed for text being shown
    public bool spedUp;    // True if text in current box has been sped up

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            // Speed up text if user presses space
            if (Input.GetKeyDown(KeyCode.Space) && charIndex > 1)
            {
                spedUp = true;
                typewriterSpeed += 100;
            }

            t += Time.deltaTime * typewriterSpeed;      // Track time
            charIndex = Mathf.FloorToInt(t);    // Store the time in seconds
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);   // Make sure charIndex doesn't exceed the length of the text

            textLabel.text = textToType.Substring(0, charIndex);    // Print a character out

            yield return null;
        }

        textLabel.text = textToType;
    }
}
