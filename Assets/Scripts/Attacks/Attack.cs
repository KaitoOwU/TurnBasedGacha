using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Attack", menuName = "TBG Menu/Create New Attack")]
public class Attack : ScriptableObject
{
    public string name;
    [TextArea] public string description;
    public int PVCost, PCCost;

    public void Launch(List<Enemy> targets)
    {

    }

    public void Launch(Enemy target)
    {

    }

    public void Launch(List<Hero> targets)
    {

    }

    public void Launch(Hero target)
    {

    }
}
