using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _imageButton;
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _imageButton.sprite = _pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _imageButton.sprite = _default;
    }  
}
