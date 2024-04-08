using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct GameData
{

}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public GameData _GameData = new GameData();

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