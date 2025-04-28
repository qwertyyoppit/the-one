using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGeneration : MonoBehaviour
{
    public Vector2Int worldSize;
    [Range(0.001f, 1)] public float noiseFreq = 0.05f;
    [Range(0f, 1f)] public float noiseLimit = 0.5f;
    public float seed;
    public Texture2D noiseTexture;

    public BaseTile baseTile;
    private Tilemap Tilemap;

    private void Awake()
    {
        Tilemap = GetComponent<Tilemap>();
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
        float noiseMult = 1f;

        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                if (y > worldSize.y * .8f) noiseMult = 0;
                else if (y > worldSize.y * .7f) noiseMult = 5f;
                else noiseMult = 1f;
                float v = Mathf.Clamp01(Mathf.PerlinNoise((x + seed) * noiseFreq, (y + seed) * noiseFreq) * noiseMult);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));
            }
        }

        noiseTexture.Apply();
    }

    public void GenerateTerrain()
    {
        Tilemap.InsertCells(new Vector3Int(-worldSize.x / 2, -worldSize.y / 2), new Vector3Int(worldSize.x, worldSize.y));
        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                if (noiseTexture.GetPixel(x, y).r > noiseLimit)
                {
                    Tilemap.SetTile(new Vector3Int(x, y), baseTile);
                }
            }
        }
    }
}
