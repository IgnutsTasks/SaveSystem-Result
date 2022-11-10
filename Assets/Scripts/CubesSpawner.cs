using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawner : MonoBehaviour
{
    public static CubesSpawner Instance { get; private set; }

    [SerializeField] private Cube[] cubes;
    [SerializeField] private Transform spawnPoint;

    public readonly List<Cube> SpawnedCubes = new List<Cube>();

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void SpawnCube()
    {
        SpawnedCubes.Add(
            Instantiate(cubes[Random.Range(0, cubes.Length)], spawnPoint.position, Quaternion.identity));
    }

    public void SpawnCube(string id, Vector3 position, Quaternion rotation)
    {
        SpawnedCubes.Add(Instantiate(GetCubeByID(id), position, rotation));
    }

    public Cube GetCubeByID(string id)
    {
        return Array.Find(cubes, cube => cube.ID == id);
    }

}
