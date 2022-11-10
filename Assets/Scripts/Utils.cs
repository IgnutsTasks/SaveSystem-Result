using UnityEngine;

public static class Utils
{
    public static string GameDataFileName => "gamedata.json";
    public static string SaveGameDataPath => Application.persistentDataPath + "/" + GameDataFileName;
}
