using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Controler
{
    private void Update()
    {
        InvokeEventMove(new Vector2(Input.GetAxis("Horizontal"), 0f));
        if (Input.GetKeyDown(KeyCode.W))
            InvokeEventJump();
    }
}
