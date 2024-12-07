using UnityEngine;
using TMPro;
using System.Collections;

public class ReusableFloatingPoint : MonoBehaviour
{
    public float floatSpeed = 50f; // Speed of upward movement
    public float duration = 2f; // How long the popup is visible
    public float fadeOutTime = 1f; // Time it takes to fade out

    private RectTransform rectTransform;
    private TextMeshProUGUI textMesh;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textMesh = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Save the initial position for reuse
        initialPosition = rectTransform.anchoredPosition;
    }

    public void ShowPopup(Vector3 playerPosition, Vector3 offset, string text, Color color)
    {
        // Set text and color
        textMesh.text = text;
        textMesh.color = color;

        // Reset position to player's position minus the offset
        rectTransform.position = playerPosition - offset;

        // Reset opacity and enable
        canvasGroup.alpha = 1f;
        gameObject.SetActive(true);

        // Start the animation
        StopAllCoroutines(); // Stop any previous animations
        StartCoroutine(AnimatePopup());
    }


    private IEnumerator AnimatePopup()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = rectTransform.anchoredPosition;
        Vector3 endPosition = startPosition + Vector3.up * 50f; // Adjust distance as needed

        // Move and fade out
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolate position
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);

            // Fade out if in fade-out period
            if (elapsedTime > (duration - fadeOutTime))
            {
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, (elapsedTime - (duration - fadeOutTime)) / fadeOutTime);
            }

            yield return null;
        }

        // Hide the popup after the animation
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }
}