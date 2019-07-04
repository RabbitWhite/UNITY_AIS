using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    Dropdown dropdownComponent;

    AIController aiController;

    public Text seekFleeText;


    void Start()
    {
        dropdownComponent = GetComponent<Dropdown>();

        dropdownComponent.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdownComponent);
        });

        aiController = (AIController) GameObject.FindGameObjectWithTag("AI_antagonist").GetComponent<AIController>();
    }

    void DropdownValueChanged(Dropdown changedDropdown)
    {
         aiController.selectedBehaviour = (AIController.Behaviour) changedDropdown.value;
    }
}
