using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class DamageResist : MonoBehaviour
{
    private ResistPhysDamage _physResist;
    private ResistColdDamage _coldResist;
    private ResistFireDamage _fireResist;
    private ResistLightningDamage _lightningResist;

    private void Start()
    {
        if(gameObject.TryGetComponent<ResistPhysDamage>(out ResistPhysDamage physResist))
            _physResist = physResist;

        if (gameObject.TryGetComponent<ResistColdDamage>(out ResistColdDamage coldResist))
            _coldResist = coldResist;

        if (gameObject.TryGetComponent<ResistFireDamage>(out ResistFireDamage fireResist))
            _fireResist = fireResist;

        if (gameObject.TryGetComponent<ResistLightningDamage>(out ResistLightningDamage lightningResist))
            _lightningResist = lightningResist;
    }

    public float CountValue(DamageType damage)
    {
        if(damage is PhysDamage && _physResist != null)
            return damage.Value * _physResist.Value;
        
        if(damage is ColdDamage && _coldResist != null)    
            return damage.Value * _coldResist.Value;

        if (damage is FireDamage && _fireResist != null)
            return damage.Value * _fireResist.Value;

        if (damage is LightningDamage && _lightningResist != null)
            return damage.Value * _lightningResist.Value; 

        return damage.Value;
    }
}
