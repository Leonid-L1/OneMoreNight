using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private EnemySpawnOrder _spawnOrder;

    private int _currentLevel = 0;

    private void StartLevel()
    {
        _spawnOrder.SpawnEnemies(_levels[_currentLevel]);
    }
}
