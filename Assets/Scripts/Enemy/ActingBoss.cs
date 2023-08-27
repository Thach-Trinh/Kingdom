using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActingBoss : MonoBehaviour
{
    public Animation anim;
    public AudioSource audi;
    public void LookAround() => anim.Play("idle break01");
    public void Scream()
    {
        audi.Play();
        anim.Play("idle break02");
    }
    public void GiveOrder() => anim.Play("casting");
    public void Walk() => anim.Play("walk");
    public void Stop() => anim.Play("idle");
}
