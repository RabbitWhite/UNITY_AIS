using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* http://www.theappguruz.com/blog/beginners-guide-learn-to-make-simple-virtual-joystick-in-unity */

public class VJHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image jsContainer;
    public Image joystick;

    public float InputForceX;
    public float InputForceY;

    void Start()
    {

        //jsContainer = GetComponent<Image>();
        //joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputForceX = 0.0f;
        InputForceY = 0.0f;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputForceX = x;
        InputForceX = (InputForceX > 1) ? 1 : InputForceX;

        InputForceY = x;
        InputForceY = (InputForceY > 1) ? 1 : InputForceY;

        //to define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector3(InputForceX * (jsContainer.rectTransform.sizeDelta.x / 3)
                                                               , InputForceY * (jsContainer.rectTransform.sizeDelta.y) / 3);

    }

    public void OnPointerDown(PointerEventData ped)
    {

        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {

        InputForceX = 0.0f;
        InputForceY = 0.0f;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
