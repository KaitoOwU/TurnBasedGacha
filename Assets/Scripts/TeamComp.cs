using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamComp : MonoBehaviour
{
    [SerializeField] Slot[] _slots = new Slot[4];
    public Slot[] Slots { get => _slots; }

    private void Start()
    {
        if(_slots.Length > 0){
            for (int i = 0; i < GameManager.Instance.CurrentTeam.Count; i++)
            {
                Hero h = GameManager.Instance.CurrentTeam[i];

                if(h == null)
                {
                    _slots[i].Setup(-1);
                } else
                {
                    _slots[i].Setup(h.id);
                }
            }
        }
    }
}
