using UnityEngine;

public class Effect_Wee : Minigame
{
    [Header("Spin Settings")]
    private Transform cameraTransform; // Reference to the camera transform
    [SerializeField] private float spinDuration = 2f; // Duration of the spin in seconds
    [SerializeField] private bool clockwise = true; // Direction of the spin
    [SerializeField] private int spinCount = 1; // Number of full 360-degree spins

    private Coroutine spinRoutine;

    public override void OnAwake()
    {
        cameraTransform = gameObject.transform; // Get the main camera's transform
        if (cameraTransform == null)
        {
            Debug.LogError("Main camera not found!"); // Log an error if the main camera is not found
        }
    }

    // Public method to trigger the spin effect
    public override void Trigger()
    {
        if (spinRoutine != null)
        {
            StopCoroutine(spinRoutine); // Stop any ongoing spin
        }
        OnTriggered?.Invoke(); // Invoke the OnTriggered event if assigned
        spinRoutine = StartCoroutine(SpinCamera());
    }

    private System.Collections.IEnumerator SpinCamera()
    {
        float elapsed = 0f;
        float totalDuration = spinDuration * spinCount; // Total duration based on spin count
        float startRotation = cameraTransform.eulerAngles.z; // Get the current Z rotation
        float targetRotation = startRotation + (clockwise ? 360f * spinCount : -360f * spinCount); // Calculate the target rotation

        while (elapsed < totalDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / totalDuration;

            // Smoothly interpolate the rotation
            float currentRotation = Mathf.Lerp(startRotation, targetRotation, progress);
            cameraTransform.eulerAngles = new Vector3(
                cameraTransform.eulerAngles.x,
                cameraTransform.eulerAngles.y,
                currentRotation
            );

            yield return null;
        }

        // Ensure the rotation ends exactly at the target
        cameraTransform.eulerAngles = new Vector3(
            cameraTransform.eulerAngles.x,
            cameraTransform.eulerAngles.y,
            targetRotation
        );

        spinRoutine = null; // Reset the routine reference
        OnCompleted?.Invoke(); // Invoke the OnCompleted event if assigned
    }
}
