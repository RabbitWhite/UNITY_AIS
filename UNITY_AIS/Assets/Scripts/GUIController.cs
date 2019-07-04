using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    Dropdown dropdownComponent;

    AIController aiController;

    public Text nameOfBehaviour;

    public Text descriptionOfBehaviour;

    Text protagonistHUD;

    GameObject antagonist;

    Text antagonistHUD;

    GameObject protagonist;

    void Start()
    {
        dropdownComponent = GetComponentInChildren<Dropdown>();

        dropdownComponent.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdownComponent);
        });

        aiController = (AIController) GameObject.FindGameObjectWithTag("AI_antagonist").GetComponent<AIController>();

        nameOfBehaviour = (Text)gameObject.transform.Find("General Info").Find("Behaviour Name").GetComponent<Text>();
        descriptionOfBehaviour = (Text)gameObject.transform.Find("General Info").Find("Behaviour Description").GetComponent<Text>();

        protagonist = GameObject.FindGameObjectWithTag("Player");
        protagonistHUD = (Text)gameObject.transform.Find("ObjectHUDs").Find("ProtagonistHUD").GetComponent<Text>();

        // Calculate *screen* position (note, not a canvas/recttransform position)
        Vector2 canvasPos = new Vector2();
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(protagonist.transform.position);

        Vector2 adjustedScreenPoint = new Vector3(screenPoint.x, screenPoint.y + 75);

        RectTransform canvasRect = (RectTransform) this.transform;

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, adjustedScreenPoint, null, out canvasPos);

        // Set
        protagonistHUD.transform.localPosition = canvasPos;

        antagonist = GameObject.FindGameObjectWithTag("AI_antagonist");
        antagonistHUD = (Text)gameObject.transform.Find("ObjectHUDs").Find("AntagonistHUD").GetComponent<Text>();

        // Calculate *screen* position (note, not a canvas/recttransform position)
        canvasPos = new Vector2();
        screenPoint = Camera.main.WorldToScreenPoint(antagonist.transform.position);

        adjustedScreenPoint = new Vector3(screenPoint.x, screenPoint.y + 75);

        canvasRect = (RectTransform)this.transform;

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, adjustedScreenPoint, null, out canvasPos);

        // Set
        antagonistHUD.transform.localPosition = canvasPos;
    }

    void DropdownValueChanged(Dropdown changedDropdown)
    {
        aiController.selectedBehaviour = (AIController.Behaviour) changedDropdown.value;
    }

    private void FixedUpdate()
    {
        // Calculate *screen* position (note, not a canvas/recttransform position)
        Vector2 canvasPos = new Vector2();
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(protagonist.transform.position);

        Vector2 adjustedScreenPoint = new Vector3(screenPoint.x, screenPoint.y + 75);

        RectTransform canvasRect = (RectTransform)this.transform;

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, adjustedScreenPoint, null, out canvasPos);

        // Set
        protagonistHUD.transform.localPosition = canvasPos;

        antagonist = GameObject.FindGameObjectWithTag("AI_antagonist");
        antagonistHUD = (Text)gameObject.transform.Find("ObjectHUDs").Find("AntagonistHUD").GetComponent<Text>();

        // Calculate *screen* position (note, not a canvas/recttransform position)
        canvasPos = new Vector2();
        screenPoint = Camera.main.WorldToScreenPoint(antagonist.transform.position);

        adjustedScreenPoint = new Vector3(screenPoint.x, screenPoint.y + 75);

        canvasRect = (RectTransform)this.transform;

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, adjustedScreenPoint, null, out canvasPos);

        // Set
        antagonistHUD.transform.localPosition = canvasPos;
    }


}
