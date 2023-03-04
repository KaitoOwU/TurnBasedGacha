using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "TBG Menu/Create New Hero")]
public class Hero : ScriptableObject
{
    public int id;
    public Sprite _sprite;
    public string name;
    public Rarity rarity;
    public bool unlocked;
    [TextArea] public string description;

    public int PV, PC, ATK, DEF, SPD, CRIT;

    public Attack[] attacks = new Attack[4];
}

public enum Rarity
{
    R,
    SR,
    SSR
}
