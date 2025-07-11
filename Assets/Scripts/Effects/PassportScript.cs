using UnityEngine;
using UnityEngine.EventSystems;

public class PassportScript : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public StampScript stamp;      // drag your Stamp GameObject here in the Inspector
    private Vector3 _offset;
    private RectTransform _rt;
    public enum StampedState
    {
        None,
        Accept,
        Deny
    }
    public StampedState stampedState = StampedState.None;

    void Awake()
    {
        _rt = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(eventData.position);
        _offset = transform.position - new Vector3(wp.x, wp.y, transform.position.z);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move the passport
        Vector3 wp = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(wp.x + _offset.x, wp.y + _offset.y, transform.position.z);

        // *right after* you move it, re–check overlap
        stamp?.CheckOverlap(_rt);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // final overlap check if you need to stamp on drop
        stamp?.CheckOverlap(_rt);
    }
}
