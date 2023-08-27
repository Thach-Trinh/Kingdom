using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachLine : MonoBehaviour
{
    
    public LineRenderer render;
    public ZombieDog dog;

    private void Start()
    {
        render.positionCount = 2;
        
    }

    private void Update()
    {
        render.SetPosition(0, dog.transform.position);
        CharacterManagement target = dog.target;
        if (target) render.SetPosition(1, target.transform.position);
    }
    
}
