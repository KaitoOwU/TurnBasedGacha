using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour
{
    [SerializeField] int _associatedSlotNumber;
    [SerializeField] UnityEngine.UI.Image _sprite;
    [SerializeField] TextMeshProUGUI _text;

    [SerializeField] GameObject _uiArrow;
    [SerializeField] Sprite _emptySprite;

    int _associatedHeroID = -1;
    bool _selected = false;
    GameObject _instantiatedArrows;

    public int HeroID { get => _associatedHeroID; set => _associatedHeroID = value; }

    public void Setup(int id)
    {
        Assert.IsTrue(id >= -1);
        if(id == -1)
        {
            _sprite.sprite = _emptySprite;
            _text.text = "Empty";
        } else
        {
            Hero h = GameManager.Instance.GetHeroFromID(id);
            _sprite.sprite = h._sprite;
            _associatedHeroID = h.id;
            string str = h.name;
            switch (h.rarity)
            {
                case Rarity.R:
                    str += "<br><size=70><#0077ff>• R •<color=white><size=30><br>";
                    break;

                case Rarity.SR:
                    str += "<br><size=70><#d000ff>• SR •<color=white><size=30><br>";
                    break;

                case Rarity.SSR:
                    str += "<br><size=70><#ffd500>• SSR •<color=white><size=30><br>";
                    break;
            }
            str += h.description;
            _text.text = str;
        }
    }

    public void Setup()
    {
        Setup(_associatedHeroID);
    }

    public void OnClicked()
    {
        if (_selected)
        {
            _selected = false;
            Destroy(_instantiatedArrows);
            foreach(UnityEngine.UI.Button _b in FindObjectsOfType<UnityEngine.UI.Button>())
            {
                if (_b != GetComponent<UnityEngine.UI.Button>())
                {
                    _b.interactable = true;
                }
            }
            TeamComp _t = FindObjectOfType<TeamComp>();
            foreach (Slot _s in _t.Slots)
            {
                if (_s != this)
                {
                    if (_s.HeroID == HeroID)
                    {
                        _s.HeroID = -1;
                        _s.Setup();
                    }
                }
            }
        } else
        {
            _selected = true;
            _instantiatedArrows = Instantiate(_uiArrow, transform);
            foreach (UnityEngine.UI.Button _b in FindObjectsOfType<UnityEngine.UI.Button>())
            {
                if(_b != GetComponent<UnityEngine.UI.Button>())
                {
                    _b.interactable = false;
                }
            }
        }
    }

    public void OnMoved()
    {
        if (_selected)
        {
            Vector2 _v = GameManager.Instance.UIInteraction.action.ReadValue<Vector2>();
            if (_v.x > 0)
            {
                while (true)
                {
                    _associatedHeroID++;
                    Debug.Log(_associatedHeroID);
                    if (_associatedHeroID > GameManager.Instance.GetHeroesSize())
                    {
                        _associatedHeroID = -1;
                    }

                    if ((GameManager.Instance.GetHeroFromID(_associatedHeroID) != null && GameManager.Instance.GetHeroFromID(_associatedHeroID).unlocked) ||
                        _associatedHeroID == -1)
                    {
                        break;
                    }
                }
                Setup();
            } else if(_v.x < 0)
            {
                while (true)
                {
                    _associatedHeroID--;
                    Debug.Log(_associatedHeroID);
                    if (_associatedHeroID < -1)
                    {
                        _associatedHeroID = GameManager.Instance.GetHeroesSize() - 1;
                    }

                    if (GameManager.Instance.GetHeroFromID(_associatedHeroID) != null && GameManager.Instance.GetHeroFromID(_associatedHeroID).unlocked ||
                        _associatedHeroID == -1)
                    {
                        break;
                    }
                }
                Setup();
            }
        }
    }
}
