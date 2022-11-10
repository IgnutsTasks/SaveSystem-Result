using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    public  List<CubeData> cubes = new List<CubeData>();
}

[Serializable]
public struct CubeData
{
    public string id;
    public Vector3 position;
    public Quaternion rotation;
    
    public CubeData(string id, Vector3 position, Quaternion rotation)
    {
        this.id = id;
        this.position = position;
        this.rotation = rotation;
    }
}

public class SaveManager : MonoBehaviour
{
    public void Save()
    {
        GameData gameData = new GameData();
        foreach (var cube in CubesSpawner.Instance.SpawnedCubes)
        {
            gameData.cubes.Add(new CubeData(cube.ID, cube.transform.position, cube.transform.rotation));
        }

        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(Utils.SaveGameDataPath, jsonData);
        
        Debug.Log("Data saved success!");
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(Utils.SaveGameDataPath);
        GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

        foreach (var cube in gameData.cubes)
        {
            CubesSpawner.Instance.SpawnCube(cube.id, cube.position, cube.rotation);
        }
        
        Debug.Log("Data load success!");
    }
}
