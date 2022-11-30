using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("Server Started");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server Stoped");
    }

    public override void OnClientConnect()
    {
        Debug.Log("Connected t server");
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("Disconnected from server");
    }
}
