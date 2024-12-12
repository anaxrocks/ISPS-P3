using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string description; // The description for this upgrade
    public TextMeshProUGUI descriptionText; // Reference to the TextMeshPro UI component
    public RectTransform tooltipPanel; // Reference to the Panel (background)

    void Update()
    {
        if (descriptionText.gameObject.activeSelf)
        { 
            Vector3 mousePosition = Input.mousePosition;
            tooltipPanel.transform.position = mousePosition + new Vector3(175, 0, 0);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the description when the pointer enters the object
        if (descriptionText != null)
        {
            descriptionText.text = description;
            descriptionText.gameObject.SetActive(true);
            tooltipPanel.gameObject.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the description when the pointer exits the object
        if (descriptionText != null)
        {
            descriptionText.text = "";
            descriptionText.gameObject.SetActive(false);
            tooltipPanel.gameObject.SetActive(false);
        }
    }
}
