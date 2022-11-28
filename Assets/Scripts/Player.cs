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
    }
}
