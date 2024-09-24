using UnityEngine;

[RequireComponent (typeof(DamageResist))]
public abstract class ResistDamageType : MonoBehaviour
{
    [Range (0.1f,0.9f)]
    [SerializeField] private float _value;

    public float Value => _value;
}
