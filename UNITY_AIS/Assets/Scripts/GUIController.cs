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

    void Start()
    {
        dropdownComponent = GetComponentInChildren<Dropdown>();

        dropdownComponent.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdownComponent);
        });

        aiController = (AIController) GameObject.FindGameObjectWithTag("AI_antagonist").GetComponent<AIController>();

        nameOfBehaviour = (Text)gameObject.transform.Find("General Info").Find("Behaviour Name").GetComponent<Text>();
        descriptionOfBehaviour = (Text)gameObject.transform.Find("General Info").Find("Behaviour Description").GetComponent<Text>();
    }

    void DropdownValueChanged(Dropdown changedDropdown)
    {
        aiController.selectedBehaviour = (AIController.Behaviour) changedDropdown.value;
    }
}
