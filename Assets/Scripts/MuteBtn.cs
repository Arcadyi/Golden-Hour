using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MuteBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image muteIcon;
    public Sprite soundOffHover;
    public Sprite soundOnHover;
    public Sprite soundOff;
    public Sprite soundOn;
    bool isMuted = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        isMuted = !isMuted;
        if (isMuted)
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
        if (isMuted)
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
        if (isMuted)
        {
            muteIcon.sprite = soundOff;
        }
        else
        {
            muteIcon.sprite = soundOn;
        }
    }
}
