using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using AGXUnity.Model; // Not usefull, DeformableTerrain stuf is read-only anyway

public class DefineTerrain : MonoBehaviour {

    public int depth = 20;
    public int terrainSize = 100; // Size of the side of the square, in meters
    public int pointPerMeter = 10; // Points per meter
    public float noiseScale = 4.0f;
    public float noiseHeight = 0.1f;

    void Update() {
    }

    void Awake() {
        Terrain terrain = gameObject.GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        // gameObject.GetComponent<DeformableTerrain>().Terrain = terrain;
    }

    TerrainData GenerateTerrain(TerrainData terrainData) {
        // terrainData.heightmapResolution = this.width + 1;
        terrainData.heightmapResolution = (int) this.terrainSize * pointPerMeter;
        terrainData.size = new Vector3(this.terrainSize, this.depth, this.terrainSize);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights() {
        int terrainPoints = (int) this.terrainSize * this.pointPerMeter;
        float[,] heights = new float[terrainPoints, terrainPoints];
        for (int widthIndex = 0; widthIndex < terrainPoints; widthIndex++) {
            for (int heightIndex = 0; heightIndex < terrainPoints; heightIndex++) {
                heights[widthIndex, heightIndex] = CalculateHeight(widthIndex, heightIndex);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y) {
        float xCoord = ((float) x) / this.terrainSize * this.noiseScale;
        float yCoord = ((float) y) / this.terrainSize * this.noiseScale;
        return Mathf.PerlinNoise(xCoord, yCoord) * this.noiseHeight;
    }
}
