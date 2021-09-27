using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTerrain : MonoBehaviour {

    private float[,] target;

    void Start() {
        Terrain terrain = gameObject.GetComponent<Terrain>();
        // terrain.terrainData.GetHeights(0, 0, );
    }

    void Update() {

    }
}
