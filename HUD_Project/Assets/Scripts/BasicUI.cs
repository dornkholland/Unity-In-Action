using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{

    public void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 40, 20), "Test"))
        {
            Debug.Log("Test button");
        }

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
