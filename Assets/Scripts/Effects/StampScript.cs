using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;  // if you need it for the Image component

public class StampScript : MonoBehaviour
{
    // Public so you can inspect it in the editor or read it from other scripts:
    public bool isPassportUnder = false;
    public Animator animator; // Reference to the Animator component

    public Sprite acceptStamp; // Assign the accept stamp sprite in the Inspector
    public Sprite denyStamp;   // Assign the deny stamp sprite in the Inspector

    public GameObject stampImage; // Assign the stamp image GameObject in the Inspector
    public PassportScript passportScript; // Reference to the PassportScript

    // Cache our own RectTransform
    private RectTransform _rt;

    public UnityEvent OnStampAccepted; // Event to trigger when the stamp is accepted
    public UnityEvent OnStampDenied;   // Event to trigger when the stamp is denied
    void Awake()
    {
        _rt = GetComponent<RectTransform>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Call this whenever the passport moves (e.g. from your drag script)
    public void CheckOverlap(RectTransform passportRt)
    {
        // Build screen‐space rects for each element
        Rect r1 = GetScreenRect(_rt);
        Rect r2 = GetScreenRect(passportRt);

        bool overlap = r1.Overlaps(r2);
        if (overlap != isPassportUnder)
        {
            isPassportUnder = overlap;
            Debug.Log($"[Stamp] Passport under stamp = {isPassportUnder}");
        }
    }

    // Converts a RectTransform into a screen‐space Rect
    private Rect GetScreenRect(RectTransform t)
    {
        Vector3[] worldCorners = new Vector3[4];
        t.GetWorldCorners(worldCorners);

        // corners[0] = bottom‐left, [2] = top‐right
        Vector2 bl = RectTransformUtility.WorldToScreenPoint(null, worldCorners[0]);
        Vector2 tr = RectTransformUtility.WorldToScreenPoint(null, worldCorners[2]);
        return new Rect(bl, tr - bl);
    }

    public void TriggerBtn(int btn)
    {
        if (isPassportUnder == false)
        {
            Debug.Log("No passport under stamp");
            return;
        }

        // Adjust the position of the stamp image based on the stamp's position relative to the passport
        RectTransform stampRect = _rt;
        RectTransform passportRect = stampImage.GetComponent<RectTransform>(); // Assuming the passport is the reference

        Vector3 stampPosition = stampRect.position;
        Vector3 passportPosition = passportRect.position;

        // Calculate the offset between the stamp and the passport
        Vector3 offset = stampPosition - passportPosition;

        // Adjust the stamp image's position based on the offset
        stampImage.GetComponent<RectTransform>().anchoredPosition += new Vector2(offset.x, offset.y);

        if (btn == 0)
        {
            Debug.Log("Button 1 pressed");
            // Trigger the stamp animation
            animator.SetTrigger("Accept"); // Assuming you have a trigger parameter named "Accept" in your Animator
            // Change the stamp image to the accept stamp
            stampImage.GetComponent<Image>().sprite = acceptStamp; // Change the sprite to the accept stamp
            stampImage.gameObject.SetActive(true); // Show the stamp image
            passportScript.stampedState = PassportScript.StampedState.Accept; // Set the stamped state to accept
            OnStampAccepted?.Invoke(); // Invoke the OnStampAccepted event
        }
        else if (btn == 1)
        {
            Debug.Log("Button 2 pressed");
            // Trigger the stamp animation
            animator.SetTrigger("Deny"); // Assuming you have a trigger parameter named "Deny" in your Animator
            // Change the stamp image to the deny stamp
            stampImage.GetComponent<Image>().sprite = denyStamp; // Change the sprite to the deny stamp
            stampImage.gameObject.SetActive(true); // Show the stamp image
            passportScript.stampedState = PassportScript.StampedState.Deny; // Set the stamped state to deny
            OnStampDenied?.Invoke(); // Invoke the OnStampAccepted event
        }
    }

    public void OnStampAnimationComplete()
    {
        animator.SetTrigger("Close");
    }
}
