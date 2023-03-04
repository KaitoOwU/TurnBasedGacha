using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<Hero> _listHeroes;
    [SerializeField] List<Attack> _listAttacks;
    [SerializeField] List<Enemy> _listEnemies;

    [SerializeField] List<Hero> _currentTeam;

    [SerializeField] InputActionReference _uiInteraction;
    public InputActionReference UIInteraction { get => _uiInteraction; }
    public List<Hero> CurrentTeam { get => _currentTeam; private set => _currentTeam = value; }

    private void Awake()
    {
        Assert.IsTrue(Instance == null);
        Instance = this;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public Hero GetHeroFromID(int id)
    {
        foreach(Hero _h in _listHeroes)
        {
            if (_h.id == id) 
                return _h;
        }
        return null;
    }

    public int GetHeroesSize()
    {
        return _listHeroes.Count;
    }
}
