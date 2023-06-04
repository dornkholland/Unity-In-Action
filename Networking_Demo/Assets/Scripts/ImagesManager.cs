using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private NetworkService networkService;

    private Texture2D webImage;

    public void Startup(NetworkService service)
    {
        Debug.Log("Images manager starting...");

        networkService = service;

        status = ManagerStatus.Started;
    }

    public void GetWebImage(Action<Texture2D> callback)
    {
        if (webImage == null)
        {
            StartCoroutine(networkService.DownloadImage((Texture2D image) =>
            {
                webImage = image;
                callback(webImage);
            }));
        }
        else
        {
            callback(webImage);
        }
    }
}