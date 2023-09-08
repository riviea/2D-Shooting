using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenguinInputController : PenguinController
{
    private Camera _camera;

    public void OnMove(InputValue value)
    {
        Vector2 vec = value.Get<Vector2>();
        CallMoveEvent(vec);
    }
}
