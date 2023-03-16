using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenService : MonoBehaviour
{
    [SerializeField] Vector3 dPos;

    private bool open;
    // Start is called before the first frame update

    public void Operate()
    {
        if (open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        } else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        open = !open;
    }

    public void Activate()
    {
        if (!open)
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
            open = true;
        }
    }

    public void Deactivate()
    {
        if (open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            open = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
