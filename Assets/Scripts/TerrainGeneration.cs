using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class TerrainGeneration : MonoBehaviour
{
    public Vector2Int worldSize;
    [Range(0.001f, 1)] public float noiseFreq = 0.05f;
    [Range(0f, 1f)] public float noiseLimit = 0.5f;
    public float seed;
    public Texture2D noiseTexture;

    public Block tile;
    public Block[][] tiles;

    private void Awake()
    {
        
    }

    private void Start()
    {
        RandomizeSeed();
        GenerateNoiseTexture();
        GenerateTerrain();
    }

    public void RandomizeSeed()
    {
        seed = Random.Range(-100000, 100000);
    }

    public void GenerateNoiseTexture()
    {
        noiseTexture = new Texture2D(worldSize.x, worldSize.y);

        for (var x = 0; x < noiseTexture.width; x++)
        {
            for (var y = 0; y < noiseTexture.height; y++)
            {
                var noiseMult = 1f;
                if (y > worldSize.y * .8f) noiseMult = 0;
                else if (y > worldSize.y * .7f) noiseMult = 5f;
                else noiseMult = 1f;
                var v = Mathf.Clamp01(Mathf.PerlinNoise((x + seed) * noiseFreq, (y + seed) * noiseFreq) * noiseMult);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));
            }
        }

        noiseTexture.Apply();
    }

    public void GenerateTerrain()
    {
        if (tiles != null)
        {
            foreach (var row in tiles)
            foreach (var curTile in row)
                Destroy(curTile.gameObject);
        }
        tiles = new Array[worldSize.y] as Block[][];
        for (var y = 0; y < noiseTexture.height; y++)
        {
            tiles[y] = new Block[worldSize.x];
            for (var x = 0; x < noiseTexture.width; x++)
            {
                if (noiseTexture.GetPixel(x, y).r > noiseLimit)
                {
                    var newTile = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity, transform);
                    tiles[y][x] = newTile;
                }
            }
        }
    }
}
