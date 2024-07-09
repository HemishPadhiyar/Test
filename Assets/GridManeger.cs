using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridSize = 10;
    public float tileSpacing = 1.1f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x * tileSpacing, 0, y * tileSpacing), Quaternion.identity);
                tile.name = $"Tile_{x}_{y}";
                tile.AddComponent<Tile>().Initialize(x, y);
            }
        }
    }
}
