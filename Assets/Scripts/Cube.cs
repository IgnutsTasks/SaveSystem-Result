using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private string id;

    public string ID => id;

    private void OnValidate()
    {
        if (id.Length == 0) id = "Cube";
    }
}
