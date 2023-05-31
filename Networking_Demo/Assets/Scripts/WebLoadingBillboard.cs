using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebLoadingBillboard : MonoBehaviour
{
    public void Operate()
    {
        Managers.Images.GetWebImage(OnWebImage);
    }

    private void OnWebImage(Texture2D image)
    {
        GetComponent<Renderer>().material.mainTexture = image;
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
