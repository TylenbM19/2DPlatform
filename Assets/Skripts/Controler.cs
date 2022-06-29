using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public delegate void MoveInput(Vector2 direction);
    public delegate void JumpInput();
    public event MoveInput OnMove;
    public event JumpInput OnJump;

    protected void MoveEvent(Vector2 direction)
    {
        OnMove?.Invoke(direction);
    }

    protected void JumpEvent()
    {
        OnJump?.Invoke();
    }
}
