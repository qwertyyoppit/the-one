using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveWorld
{
    public static List<string> worldAttributes = new ()
    {
        "worldSize",
    };

    public void Save(Vector2Int size, Block[][] tiles)
    {
        string data = "";
        data += "worldSize: " + size.x + "x" + size.y + "\n";
        data += "tiles: \n";
        foreach (Block[] column in tiles)
        {
            foreach (Block tile in column)
            {
                data += tile.info.TileId + ", ";
            }

            data += "\n";
        }
    }
}
