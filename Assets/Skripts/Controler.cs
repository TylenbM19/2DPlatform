using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public delegate void MoveInput(Vector2 direction);
    public delegate void JumpInput();
    public event MoveInput Moved;
    public event JumpInput Jumped;

    protected void InvokeEventControlerMove(Vector2 direction)
    {
        Moved?.Invoke(direction);
    }

    protected void InvokeEventControlerJump()
    {
        Jumped?.Invoke();
    }
}
