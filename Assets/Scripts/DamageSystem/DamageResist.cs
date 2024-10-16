using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class DamageResist : MonoBehaviour
{ 
    private Dictionary<System.Type, ResistDamageType> _resistances;
 
    private void Start()
    {
        _resistances = new Dictionary<System.Type, ResistDamageType>
        {
            { typeof(PhysDamage),GetComponent<ResistPhysDamage>() },
            { typeof(ColdDamage),GetComponent<ResistColdDamage>() },
            { typeof(FireDamage),GetComponent<ResistFireDamage>() },
            { typeof(LightningDamage),GetComponent<ResistLightningDamage>() },
            // новые типы сопротивлений добавлять здесь
        };   
    }

    public float CountValue(DamageType damage)
    {
        if (_resistances.TryGetValue(damage.GetType(), out ResistDamageType resistComponent))
            return resistComponent != null ? damage.Value * resistComponent.Value : damage.Value;

            return damage.Value;
    }
}
