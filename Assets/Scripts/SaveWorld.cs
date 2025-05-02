using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.TerrainTools;
using UnityEngine;

public class SaveWorld
{
    private static string Path => Application.persistentDataPath;
    
    public static List<string> worldAttributes = new ()
    {
        "worldSize",
    };

    public static void Save(Vector2Int size, BaseTile[][] tiles)
    {
        var data = "";
        data += "worldSize: \"" + size.x + "x" + size.y + "\"\n";
        data += "tiles: \n\"";
        foreach (var column in tiles)
        {
            data = column.Aggregate(data, (current, tile) => current + (tile + ", "));

            data += "\"\n";
        }

        var worldSave = JsonUtility.ToJson(tiles);
        File.WriteAllText(Path+"world/worldSave.wld", data);
    }

    public static BaseTile[][] GetWorld()
    {
        return JsonUtility.FromJson<BaseTile[][]>(Path+"world/worldSave.wld");
    }
}
