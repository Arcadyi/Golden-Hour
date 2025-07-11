using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class Effect_AAAAA : Minigame
{
    [Header("Post-Processing")]
    [SerializeField] private Volume postProcessingVolume;
    [SerializeField] private float maxChromaticIntensity = 1f;

    [Header("Button Presses")]
    [SerializeField] private List<ClickableButton> clickableButtons;
    [SerializeField] private float minButtonDelay = 0.05f;
    [SerializeField] private float maxButtonDelay = 0.2f;

    private ChromaticAberration _chromaticAberration;
    private Coroutine      _effectRoutine;

    public float duration = 5f;

    // override the onawake
    public override void OnAwake()
    {
        base.OnAwake();
        if (postProcessingVolume != null
            && postProcessingVolume.profile.TryGet(out ChromaticAberration ca))
        {
            _chromaticAberration = ca;
            _chromaticAberration.intensity.value = 0f;
        }
        else
        {
            Debug.LogError("Chromatic Aberration not found on Volume!");
        }
    }

    /// <summary>
    /// Public trigger: restarts the effect for exactly <paramref name="duration"/> seconds.
    /// </summary>
    public override void Trigger()
    {
        // If already running, stop first so we reset cleanly
        if (_effectRoutine != null)
            StopCoroutine(_effectRoutine);
        OnTriggered?.Invoke(); // Invoke the OnTriggered event if assigned
        _effectRoutine = StartCoroutine(RunEffect(duration));
    }

    private IEnumerator RunEffect(float duration)
    {
        float startTime = Time.time; // Record the start time
        const float rampUpPortion = 0.7f; // 70% of time is ramp-up, last 30% is fast drop

        while (Time.time - startTime < duration)
        {
            float elapsed = Time.time - startTime;
            float progress = Mathf.Clamp01(elapsed / duration);

            // Easing: slow linear ramp until 70%, then fast linear falloff
            float intensity;
            if (progress < rampUpPortion)
            {
                intensity = maxChromaticIntensity * (progress / rampUpPortion);
            }
            else
            {
                intensity = maxChromaticIntensity * ((1f - progress) / (1f - rampUpPortion));
            }

            _chromaticAberration.intensity.value = intensity;

            // Random button clicks at a rate that follows the intensity curve:
            if (clickableButtons != null && clickableButtons.Count > 0)
            {
                // More intense = faster clicks
                float t = intensity / maxChromaticIntensity;
                float delay = Mathf.Lerp(maxButtonDelay, minButtonDelay, t);

                int idx = Random.Range(0, clickableButtons.Count);
                clickableButtons[idx].PlayClickAnimation();

                yield return new WaitForSecondsRealtime(delay); // Use unscaled time for consistent delays
            }
            else
            {
                yield return null;
            }
        }

        // Clean up
        _chromaticAberration.intensity.value = 0f;
        _effectRoutine = null;
        OnCompleted?.Invoke(); // Invoke the OnCompleted event if assigned
    }
}
