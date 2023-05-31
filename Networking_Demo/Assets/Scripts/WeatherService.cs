using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherService : MonoBehaviour
{
    public ManagerStatus status { get; private set; }

    private NetworkService network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");

        status = ManagerStatus.Started;
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
