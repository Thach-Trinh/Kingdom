using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private CursorBaseState state;
    private void Start()
    {
        ChangeState(new CursorGameState());
    }
    private void Update()
    {
        state.UpdateState();
    }

    public void ChangeState(CursorBaseState newState)
    {
        if (state != null)
        {
            state.ExitState();
        }
        state = newState;
        if (state != null)
        {
            state.EnterState();
        }
    }

}

public abstract class CursorBaseState
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}

public class CursorGameState: CursorBaseState
{
    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        bool isReleased = Input.GetKey(KeyCode.LeftAlt);
        Cursor.lockState = isReleased ? CursorLockMode.None : CursorLockMode.Locked;
    }
}

public class CursorPauseState : CursorBaseState
{
    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState() { }

}

