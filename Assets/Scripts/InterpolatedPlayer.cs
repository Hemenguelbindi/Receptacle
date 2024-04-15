using UnityEngine;

public class TerrainSlider : MonoBehaviour
{
    CharacterController controller;
    Terrain terrain;
    float slideForce = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        terrain = Terrain.activeTerrain;
    }

    void Update()
    {
        
        Vector3 position = transform.position;

        
        Vector3 normal = terrain.terrainData.GetInterpolatedNormal(position.x / terrain.terrainData.size.x,
                                                                   position.z / terrain.terrainData.size.z);

        // Применяем скольжение к персонажу
        controller.Move(normal * slideForce * Time.deltaTime);
    }
}
