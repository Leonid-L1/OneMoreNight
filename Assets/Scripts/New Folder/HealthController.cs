using UnityEngine;
[RequireComponent (typeof(DamageResist))]
public class HealthController : MonoBehaviour
{
    [SerializeField] private float _health;
    private DamageResist _resist;

    private void Start() => _resist = GetComponent<DamageResist>();
    
    public float Health => _health;

    public void GetDamage(DamageType damage)
    {
        float damageValue = _resist.CountValue(damage);

        if (_health <= 0) return;

        if (damageValue >= _health)
        {
            _health = 0;
            Die();
            return;
        }
            
        _health -= damageValue;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {

    }
}
