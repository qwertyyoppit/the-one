using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGeneration))]
public class TerrainGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TerrainGeneration terrainGenerator = (TerrainGeneration)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Randomize Seed"))
        {
            terrainGenerator.RandomizeSeed();
        }
        GUILayout.Space(2);
        if (GUILayout.Button("Generate Noise"))
        {
            terrainGenerator.GenerateNoiseTexture();
        }
        GUILayout.Space(2);
        if (GUILayout.Button("Generate Terrain"))
        {
            terrainGenerator.GenerateTerrain();
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Generate Both"))
        {
            terrainGenerator.GenerateNoiseTexture();
            terrainGenerator.GenerateTerrain();
        }
    }
}
