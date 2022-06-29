using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Controler
{
    private void Update()
    {
        MoveEvent(new Vector2(MoveClickedButton(), 0f));    
        if (JumpClickedButton())
            JumpEvent();
    }

    private float MoveClickedButton()
    {
        return Input.GetAxis("Horizontal");
    }
    
    private bool JumpClickedButton()
    {
        return Input.GetKeyDown(KeyCode.W);
    }
}
