using UnityEngine;
using System.Collections;

public class Effect_Arstotzka : Minigame
{
    public StampScript stamp;
    public PassportScript passport;
    public Vector2 passportStartPosition; // set in the Inspector to the “Anchored Position” you want
    public Vector2 passportEndPosition;   // same here
    public float passportAppearSpeed = 1f;

    private RectTransform _rt;

    private PassportScript passportScript;
    private StampScript stampScript;

    public override void OnAwake()
    {
        // cache the RectTransform for easier use
        _rt = passport.GetComponent<RectTransform>();

        // ensure it starts hidden or at the start position
        _rt.anchoredPosition = passportStartPosition;
        passport.gameObject.SetActive(false);
        stamp.gameObject.SetActive(false);
        passportScript = passport.GetComponent<PassportScript>();
        stampScript = stamp.GetComponent<StampScript>();
    }


    public override void Trigger()
    {
        OnTriggered?.Invoke();

        if (passport != null)
        {
            passport.gameObject.SetActive(true);
            StartCoroutine(PassportAppear());
            stamp.gameObject.SetActive(true);
            stampScript.animator.SetTrigger("Open");
        }
        else
        {
            Debug.LogError("Passport reference is not set!");
        }
    }

    private IEnumerator PassportAppear()
    {
        float elapsed = 0f;

        // ensure we begin where you expect
        _rt.anchoredPosition = passportStartPosition;

        while (elapsed < passportAppearSpeed)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / passportAppearSpeed);
            _rt.anchoredPosition = Vector2.Lerp(passportStartPosition, passportEndPosition, t);
            yield return null;
        }

        // snap exactly
        _rt.anchoredPosition = passportEndPosition;
    }

    public void StartDisappear()
    {
        if (passport != null && passport.gameObject.activeSelf)
        {
            StartCoroutine(Disappear());
        }
        else
        {
            Debug.LogError("Passport reference is not set or already inactive!");
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);
        float elapsed = 0f;

        while (elapsed < passportAppearSpeed)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / passportAppearSpeed);
            _rt.anchoredPosition = Vector2.Lerp(_rt.anchoredPosition, passportStartPosition, t);
            yield return null;
        }

        // snap exactly
        _rt.anchoredPosition = passportStartPosition;
        passport.gameObject.SetActive(false);
        stamp.gameObject.SetActive(false);
        // get stampscript from stamp
        stampScript.stampImage.gameObject.SetActive(false); // Hide the stamp image
        passportScript.stampedState = PassportScript.StampedState.None; // Reset the stamped state
        OnCompleted?.Invoke(); // Invoke the OnCompleted event if assigned
    }
}
