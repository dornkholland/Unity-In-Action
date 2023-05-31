using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public float cloudValue { get; private set; }

    private NetworkService network;
    // Start is called before the first frame update

    public void Startup(NetworkService service) {
        Debug.Log("Weather manager starting...");
        
        network = service;
        /*StartCoroutine(network.GetWeatherXML(OnXMLDataLoaded));*/
        StartCoroutine(network.GetWeatherJSON(OnJSONDataLoaded));
        status = ManagerStatus.Initializing;
        status = ManagerStatus.Started;
    }

    public void OnXMLDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;

        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f;
        Debug.Log($"Value: {cloudValue}");

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);

        status = ManagerStatus.Started;
    }

    public void OnJSONDataLoaded(string data)
    {
        JObject root = JObject.Parse(data);

        JToken clouds = root["clouds"];
        cloudValue = (float)clouds["all"] / 100f;
        Debug.Log($"Value: {cloudValue}");

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);

        status = ManagerStatus.Started;
    }

    public void LogWeather(string name)
    {
        StartCoroutine(network.LogWeather(name, cloudValue, OnLogged));
    }
    private void OnLogged(string response)
    {
        Debug.Log(response);
    }
}
