using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefabsSet : MonoBehaviour
{
    public static RoomPrefabsSet Instance = null;


    public Dictionary<string, GameObject> _RoomPrefabs = new Dictionary<string, GameObject>();
    public List<string> _RoomPrefabsName;
    public List<GameObject> _RoomprefabsList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < _RoomPrefabsName.Count; i++)
        {
            _RoomPrefabs.Add(_RoomPrefabsName[i], _RoomprefabsList[i]);
        }
    }
}
