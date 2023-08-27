using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchBell : MonoBehaviour
{
    public float delay;
    public AudioSource audi;
    public void StartRinging()
    {
        Ring();
    }
    private void Ring()
    {
        audi.Play();
        Invoke(nameof(Ring), delay);
    }

    public void StopRinging()
    {
        CancelInvoke(nameof(Ring));
    }

}
