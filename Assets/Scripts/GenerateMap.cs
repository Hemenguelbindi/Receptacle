using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20;
    

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GetTerrain(terrain.terrainData);
    }

    TerrainData GetTerrain(TerrainData terrainData)
    {
        
        terrainData.size = new Vector3(width, depth, height);
        terrainData.heightmapResolution = width + 1;
        terrainData.SetHeights(0, 0, GenerateHits());
        return terrainData;
    }

    private float[,] GenerateHits()
    {
        float[,] heigths = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heigths[x, y] = CalculateHeight(x, y); 
            }
        }

        return heigths;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        return Mathf.PerlinNoise(xCoord, yCoord);


    }
}
