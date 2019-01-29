using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    Dropdown m_Dropdown;

    AIController aiController;

    public Text seekFleeText;

    Text tmp;

    void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        aiController = (AIController) GameObject.FindGameObjectWithTag("AI_antagonist").GetComponent<AIController>();
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
         aiController.selectedBehaviour = (AIController.Behaviour) change.value;

        switch ((AIController.Behaviour)change.value)
        {
            case AIController.Behaviour.Flee:
                if (tmp != null)
                    Destroy(tmp.gameObject);
                tmp = Instantiate(seekFleeText);
                tmp.gameObject.transform.SetParent(this.transform.parent);
                tmp.rectTransform.anchorMin = new Vector2(0, 1);
                tmp.rectTransform.anchorMax = new Vector2(0, 1);
                tmp.rectTransform.anchoredPosition = new Vector2(520, -50);
                tmp.text = "AI is fleeing";
                break;
            case AIController.Behaviour.Arrive:
                if (tmp != null)
                    Destroy(tmp.gameObject);
                tmp = Instantiate(seekFleeText);
                tmp.gameObject.transform.SetParent(this.transform.parent);
                tmp.rectTransform.anchorMin = new Vector2(0, 1);
                tmp.rectTransform.anchorMax = new Vector2(0, 1);
                tmp.rectTransform.anchoredPosition = new Vector2(520, -50);
                tmp.text = "AI is arriving";
                break;
            case AIController.Behaviour.Seek:
            default:
                if (tmp != null)
                    Destroy(tmp.gameObject);
                tmp = Instantiate(seekFleeText);
                tmp.gameObject.transform.SetParent(this.transform.parent);
                tmp.rectTransform.anchorMin = new Vector2(0, 1);
                tmp.rectTransform.anchorMax = new Vector2(0, 1);
                tmp.rectTransform.anchoredPosition = new Vector2(520, -50);
                tmp.text = "AI is seeking";
                break;
        }
    }
}
