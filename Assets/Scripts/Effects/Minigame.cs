using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour
{
    public UnityEvent OnTriggered; // Event to trigger when the minigame starts
    public UnityEvent OnCompleted; // Event to trigger when the minigame is completed 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
    virtual public void OnUpdate()
    {
        
    }
    
    virtual public void OnAwake()
    {
        
    }
    virtual public void Trigger()
    {
        OnTriggered?.Invoke(); // Invoke the OnTriggered event if assigned
    }
}
