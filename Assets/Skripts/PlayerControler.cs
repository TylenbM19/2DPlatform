using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Controler
{
    private void Update()
    {
        InvokeEventMove(new Vector2(ReturnButtonClickOnMovement(), 0f));
            if (ReturnButtonClickOnJump())
                InvokeEventJump();
    }

    private float ReturnButtonClickOnMovement()
    {
        return Input.GetAxis("Horizontal");
    }

    private bool ReturnButtonClickOnJump()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
}
