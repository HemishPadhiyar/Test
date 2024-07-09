using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public ObstacleData obstacleData;

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (obstacleData.obstacles[x, y])
                {
                    Instantiate(obstaclePrefab, new Vector3(x, 0, y), Quaternion.identity);
                }
            }
        }
    }
}
