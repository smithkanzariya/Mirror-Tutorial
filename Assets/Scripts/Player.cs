using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Player : NetworkBehaviour
{
    float moveHorizontal;
    float moveVertical;
    Vector3 move;
    void HandleMovements()
    {
        if(isLocalPlayer)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            move = new Vector3(-moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + move;
        }
    }

    private void Update()
    {
        HandleMovements();

        if(isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending Hola to server!");
            Hola();
        }
        
        //ClientRpc Shouldn't be called in Update Method, it is really bad practice so just for Study purpose run it otherwise kccomment it.
        //if(isServer && transform.position.y > 50)
        //{
        //    TooHigh();
        //}

        
    }

    public override void OnStartServer()
    {
        Debug.Log("Player has been spawned on ther server");
    }

    [Command] //with this attribute the method called by client and Run on Server
    void Hola()
    {
        Debug.Log("Recieved Hola from client");
        ReplyHola();
    }

    [TargetRpc] //TargetRpc functions are called by user code on the server, and then invoked on the corresponding client object on the client of the specified NetworkConnection.
    void ReplyHola()
    {
        Debug.Log("We recieved hola from server");
    }

    [ClientRpc] //with this attribute the method called by Server and Run on client
    void TooHigh()
    {
        Debug.Log("Too high!");
    }
}
