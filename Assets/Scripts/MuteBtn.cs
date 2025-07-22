using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MuteBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image muteIcon;
    public Sprite soundOffHover;
    public Sprite soundOnHover;
    public Sprite soundOff;
    public Sprite soundOn;
    private bool _isMuted;
    public void OnPointerClick(PointerEventData eventData)
    {
        _isMuted = !_isMuted;
        if (_isMuted)
        {
            muteIcon.sprite = soundOff;
        }
        else
        {
            muteIcon.sprite = soundOn;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isMuted)
        {
            muteIcon.sprite = soundOffHover;
        }
        else
        {
            muteIcon.sprite = soundOnHover;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isMuted)
        {
            muteIcon.sprite = soundOff;
        }
        else
        {
            muteIcon.sprite = soundOn;
        }
    }
}
