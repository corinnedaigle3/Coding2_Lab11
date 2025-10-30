using Unity.AI.Navigation;
using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public NavMeshSurface surface;

    public int width;
    public int height;
    [Range(0f, 1f)] public float obstacleProbability;

    public GameObject wall;
    public GameObject player;

    private Pathfinding pathfinding;

    private readonly List<GameObject> spawnedWalls = new();
    private GameObject playerInstance;

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();

        // Spawn initial player
        Vector3 playerStartPos = new Vector3(0 - width / 2f, 1.25f, 0 - height / 2f);
        playerInstance = Instantiate(player, playerStartPos, Quaternion.identity);

        GenerateRandomGrid(width, height, obstacleProbability);
        surface.BuildNavMesh();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Remove walls only (keep player)
            ClearWalls();

            // Spawn new random walls
            GenerateRandomGrid(width, height, obstacleProbability);

            // Rebuild navigation mesh
            surface.BuildNavMesh();
        }
    }

    private void ClearWalls()
    {
        foreach (var w in spawnedWalls)
        {
            if (w != null)
                Destroy(w);
        }
        spawnedWalls.Clear();
    }

    private void AddObstacle(Vector2Int position)
    {
        Vector3 posWall = new Vector3(position.x - width / 2f, 1f, position.y - height / 2f);
        GameObject w = Instantiate(wall, posWall, Quaternion.identity, transform);
        spawnedWalls.Add(w);
    }

    private void GenerateRandomGrid(int width, int height, float obstacleProbability)
    {
        for (int x = 0; x <= width; x += 2)
        {
            for (int y = 0; y <= height; y += 2)
            {
                if (Random.value < obstacleProbability)
                {
                    AddObstacle(new Vector2Int(x, y));
                }
            }
        }
    }
}