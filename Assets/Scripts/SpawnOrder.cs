using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnOrder : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Transform _bossSpawnPoint;

    private float _circleRadius = 5f;

    public void SpawnEnemies(Level currentLevel)
    {   
        if(currentLevel.EnemyType1!= null)
            for (int i = 0; i < currentLevel.EnemyType1Count; i++)
                _spawner.Spawn(currentLevel.EnemyType1, randomSpawnPoint());

        if (currentLevel.EnemyType2 != null)
            for (int i = 0; i < currentLevel.EnemyType2Count; i++)
                _spawner.Spawn(currentLevel.EnemyType2, randomSpawnPoint());

        if (currentLevel.Boss != null)
            _spawner.Spawn(currentLevel.Boss, _bossSpawnPoint.position);
    }

    public Vector2 randomSpawnPoint()
    {
        Transform randomSpawnTransform = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].transform;
        Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * _circleRadius;
        return randomPosition + new Vector2(randomSpawnTransform.position.x, randomSpawnTransform.position.y);
    }
}
