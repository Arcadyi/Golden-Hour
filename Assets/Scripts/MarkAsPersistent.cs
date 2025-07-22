using UnityEngine;

public class MarkAsPersistent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Make this object persistent
    }
}
