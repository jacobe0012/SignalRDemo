using System;
using System.Collections;
using System.Collections.Generic;
using Best.SignalR;
using Best.SignalR.Encoders;
using UnityEngine;

public class SignalRTest : MonoBehaviour
{
    private HubConnection hub;

    async void Start()
    {
        hub = new HubConnection(new Uri("https://localhost:7176/LoginHub"), new JsonProtocol(new LitJsonEncoder()));
        hub.ReconnectPolicy = new DefaultRetryPolicy();
        await hub.ConnectAsync();

        await hub.SendAsync("Login", new MyData
        {
            Age = 1,
            FirstName = "unity001lastname",
            LastName = "unity001"
        });
        Debug.Log("Connected!");
    }

    void Update()
    {
    }
}