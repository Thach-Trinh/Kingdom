using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeVillager : MonoBehaviour
{
    public float minDelay;
    public float maxDelay;
    public Animator anim;
    public Transform shadowPrefab;

    private void Start()
    {
        int rand = Random.Range(1, 3);
        anim.SetInteger("Dead", rand);
    }

    public void StartTransform()
    {
        float delay = Random.Range(minDelay, maxDelay);
        Invoke(nameof(TransformToZombie), delay);
    }

    private void TransformToZombie()
    {
        anim.SetTrigger("Transform");
        CreateMagicEffect();
    }

    private void CreateMagicEffect()
    {
        Transform shadowFog = Instantiate(shadowPrefab, transform);
        shadowFog.localPosition = new Vector3(0, 1, 0);
    }
}
