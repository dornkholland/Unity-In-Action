using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorChangeDevice : MonoBehaviour
{
    // Start is called before the first frame update

    public void Operate()
    {
        Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Renderer>().material.color = random;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
