using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : CharacterManagement
{
    public PlayerMovement movement;
    public WeaponManager weapon;
    public SuitManager suit;
    public CharacterController controller;
    public Animator anim;
    public void ActivePlayer() => SetPlayerState(true);
    public void DisablePlayer() => SetPlayerState(false);
    private void SetPlayerState(bool isActive)
    {
        movement.enabled = isActive;
        weapon.enabled = isActive;
        controller.enabled = isActive;
        //anim.SetTrigger("Idle");
        anim.SetBool("IsMoving", false);
        //anim.enabled = isActive;
    }
    public void Teleport(Vector3 destination)
    {
        transform.position = destination;
    }
}
