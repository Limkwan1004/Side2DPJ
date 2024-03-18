using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct GameData
{
    int Level;
    int Strength;
    int Dexterity;
    int Intelligence;
    int Luck;
    int SkillPoint;
    int Exprience;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public GameData _gameData = new GameData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
    }
}