using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    private CursorController cursorController;
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Messenger.Broadcast(GameEvent.CURSOR_HIDE);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
        PlayerPrefs.SetFloat("speed", speed);
    } 
    // Start is called before the first frame update
    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
