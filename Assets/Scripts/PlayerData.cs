using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    Male,
    Female
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int chapter;
    public int coin;
    public Gender gender;
    public float sound;
    public float volume;
}
