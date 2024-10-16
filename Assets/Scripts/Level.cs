using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level", order = 51)]
public class Level : ScriptableObject
{
    [SerializeField] private EnemyEntity _enemyType1;
    [SerializeField] private EnemyEntity _enemyType2;
    [SerializeField] private BossEntity _boss;
    [SerializeField] private int _enemyType1Count;
    [SerializeField] private int _enemyType2Count;

    public EnemyEntity EnemyType1 => _enemyType1;
    public EnemyEntity EnemyType2 => _enemyType2;
    public BossEntity Boss => _boss;
    public int EnemyType1Count => _enemyType1Count;
    public int EnemyType2Count => _enemyType2Count;
}
