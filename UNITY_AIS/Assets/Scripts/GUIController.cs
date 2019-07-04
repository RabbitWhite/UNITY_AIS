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

    GameObject title;
    GameObject behaviourSelector;
    GameObject generalInfo;
    GameObject objectHUDs;

    Text protagonistHUD;

    GameObject antagonist;

    Text antagonistHUD;

    GameObject protagonist;

    bool visibleGUIHUD = true;

    void Start()
    {
        title = gameObject.transform.Find("Title").gameObject;
        behaviourSelector = gameObject.transform.Find("Behaviour Selector").gameObject;
        generalInfo = gameObject.transform.Find("General Info").gameObject;
        objectHUDs = gameObject.transform.Find("Object HUDs").gameObject;

        dropdownComponent = behaviourSelector.GetComponent<Dropdown>();

        dropdownComponent.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdownComponent);
        });

        aiController = (AIController) GameObject.FindGameObjectWithTag("AI_antagonist").GetComponent<AIController>();

        nameOfBehaviour = (Text) generalInfo.transform.Find("Behaviour Name").GetComponent<Text>();
        descriptionOfBehaviour = (Text) generalInfo.transform.Find("Behaviour Description").GetComponent<Text>();

        protagonist = GameObject.FindGameObjectWithTag("Player");
        protagonistHUD = (Text) objectHUDs.transform.Find("ProtagonistHUD").GetComponent<Text>();

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
        antagonistHUD = (Text) objectHUDs.transform.Find("AntagonistHUD").GetComponent<Text>();

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            visibleGUIHUD = visibleGUIHUD == true ? false : true;

            if (visibleGUIHUD)
            {
                title.SetActive(true);
                behaviourSelector.SetActive(true);
                generalInfo.SetActive(true);
                objectHUDs.SetActive(true);
            }
            else
            {
                title.SetActive(false);
                behaviourSelector.SetActive(false);
                generalInfo.SetActive(false);
                objectHUDs.SetActive(false);
            }
        }
    }


}
