using UnityEngine;
using System.Collections;

public class Effect_Jitter : MonoBehaviour
{
    [Header("References")]
    public Transform cameraTransform;   // assign in Inspector

    [Header("Cycle Timing")]
    public float pauseBetweenBursts = 0.4f;   // idle time after returning home
    public float travelTime          = 0.15f; // how long to reach random offset & come back

    [Header("Burst Settings")]
    public float burstDuration   = 0.25f; // how long the micro-jitter lasts
    public float burstJitterAmount = 0.05f; // max shake distance while at target
    [Range(0,1)]
    public float jitterStrength = 1f;     // master scale – set to 0 to disable everything

    private Vector3 originalLocalPos;
    private Coroutine jitterCycle;

    void OnEnable()
    {
        if (!cameraTransform) cameraTransform = Camera.main.transform;
        originalLocalPos = cameraTransform.localPosition;

        if (jitterCycle != null) StopCoroutine(jitterCycle);
        jitterCycle = StartCoroutine(JitterLoop());
    }

    void OnDisable()
    {
        if (jitterCycle != null) StopCoroutine(jitterCycle);
        cameraTransform.localPosition = originalLocalPos;
    }

    IEnumerator JitterLoop()
    {
        WaitForSecondsRealtime pause = new WaitForSecondsRealtime(pauseBetweenBursts);

        while (true)
        {
            if (jitterStrength <= 0f)      // master off
            {
                cameraTransform.localPosition = originalLocalPos;
                yield return null;
                continue;
            }

            // 1) pick random offset
            Vector3 randomOffset = Random.insideUnitSphere * burstJitterAmount * jitterStrength;
            Vector3 targetLocal  = originalLocalPos + randomOffset;

            // 2) move to offset
            yield return MoveRoutine(originalLocalPos, targetLocal, travelTime);

            // 3) micro-jitter burst while staying at target
            float burstEnd = Time.time + burstDuration;
            while (Time.time < burstEnd)
            {
                Vector3 micro = Random.insideUnitSphere * burstJitterAmount * 0.5f * jitterStrength;
                cameraTransform.localPosition = targetLocal + micro;
                yield return null;
            }

            // 4) return home
            yield return MoveRoutine(targetLocal, originalLocalPos, travelTime);

            // 5) pause before the next cycle
            yield return pause;
        }
    }

    IEnumerator MoveRoutine(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            cameraTransform.localPosition = Vector3.Lerp(from, to, t);
            yield return null;
        }
        cameraTransform.localPosition = to;
    }
}