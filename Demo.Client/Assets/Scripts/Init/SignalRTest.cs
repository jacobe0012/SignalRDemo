using System;
using System.Collections;
using System.Collections.Generic;
using Best.SignalR;
using Best.SignalR.Encoders;
using Best.SignalR.Messages;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SignalRTest : MonoBehaviour
{
    private HubConnection hub;

    async void Start()
    {
        hub = new HubConnection(new Uri("https://192.168.28.112:7176/LoginHub"),
            new JsonProtocol(new LitJsonEncoder()));
        hub.ReconnectPolicy = new DefaultRetryPolicy();
        hub.OnConnected += OnConnected;
        hub.OnReconnected += OnReConnected;
        hub.OnError += OnError;
        hub.OnClosed += OnClosed;
        hub.OnMessage += OnMessage;

        await hub.ConnectAsync();
    }

    bool OnMessage(HubConnection hub, Message msg)
    {
        bool processed = false;

        Debug.Log($"OnMessage! {msg.ToString()}");

        return processed;
    }

    void OnClosed(HubConnection hub)
    {
        Debug.Log("OnClosed!");
    }

    void OnError(HubConnection hub, string msg)
    {
        Debug.Log("OnError!");
    }

    void OnConnected(HubConnection hub)
    {
        Debug.Log("OnConnected!");
    }

    void OnReConnected(HubConnection hub)
    {
        Debug.Log("OnReConnected!");
    }

    void Init()
    {
        hub.On("C_Connect", () => { Debug.Log("Connected!"); });
    }


    void Update()
    {
    }
}