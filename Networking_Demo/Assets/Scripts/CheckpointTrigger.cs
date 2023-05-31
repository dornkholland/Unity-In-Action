using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public string identifier;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) { return; }

        Managers.Weather.LogWeather(identifier);
        triggered = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
