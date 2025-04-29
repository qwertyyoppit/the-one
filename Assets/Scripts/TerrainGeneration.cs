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

    public TileBase tile;
    private Tilemap _tilemap;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    private void Start()
    {
        RandomizeSeed();
        GenerateNoiseTexture();
        GenerateTerrain();
    }

    private void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            for (int i = 0; i < 20; i++)
            {
                Vector3Int randomPos = new Vector3Int(Random.Range(0, worldSize.x), Random.Range(0, worldSize.y), 0);
                var curTile = _tilemap.GetTile(randomPos) as BaseTile;
                while (!curTile)
                {
                    randomPos = new Vector3Int(Random.Range(0, worldSize.x), Random.Range(0, worldSize.y), 0);
                    curTile = _tilemap.GetTile(randomPos) as BaseTile;
                }

                if (curTile.color == Color.white) curTile.color = Color.red;
                else if (curTile.color == Color.red) curTile.color = Color.blue;
                else if (curTile.color == Color.blue) curTile.color = Color.white;
                Debug.Log(curTile.health);

                curTile.RefreshTile(randomPos, _tilemap);
            }
        }
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
        _tilemap.InsertCells(new Vector3Int(-worldSize.x / 2, -worldSize.y / 2), new Vector3Int(worldSize.x, worldSize.y));
        for (var x = 0; x < noiseTexture.width; x++)
        {
            for (var y = 0; y < noiseTexture.height; y++)
            {
                if (noiseTexture.GetPixel(x, y).r > noiseLimit)
                {
                    _tilemap.SetTile(new Vector3Int(x, y), tile);
                }
            }
        }
    }
}
