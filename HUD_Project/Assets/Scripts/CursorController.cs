using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButton(0))
        {

        }
    }

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.CURSOR_HIDE, HideCursor);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.CURSOR_HIDE, HideCursor);
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
