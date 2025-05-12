using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.TerrainTools;
using UnityEngine;

public class SaveWorld
{
    private static string Path => Application.dataPath;
    
    public static List<string> worldAttributes = new ()
    {
        "worldSize",
        "tiles"
    };

    public static void Save(Vector2Int size, string[][] tiles)
    {
        var data = "";
        data += "worldSize: \"" + size.x + "x" + size.y + "\"\n";
        data += "\"tiles: \n\"";
        foreach (var column in tiles)
        {
            data = column.Aggregate(data, (current, tile) => current + (tile + ", "));

            data += "\"\n";
        }
        data += "\"";
        
        File.WriteAllText(Path+"/World/worldSave.wld", data);
    }

    public static void GetWorld()
    {
        var save = File.ReadAllLines(Path+"world/worldSave.wld");
        Vector2Int size;
        foreach (var line in save)
        {
            if (line.StartsWith("worldSize: "))
            {
                var coords = line.AsSpan(line.IndexOf("worldSize: ", StringComparison.Ordinal)).ToString().Split("x");
                foreach (var coord in coords)
                    Debug.Log(coord);
            }
        }
    }
}
