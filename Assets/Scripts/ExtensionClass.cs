using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionClass
{
    public static T GetRandomElement<T>(this T[] array)
    {
        int index = Random.Range(0, array.Length);
        return array[index];
    }

    public static T GetRandomElement<T>(this List<T> array)
    {
        int index = Random.Range(0, array.Count);
        return array[index];
    }
}
