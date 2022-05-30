using UnityEngine;

public interface IDamageble
{
    public float Damage { get; }

    public void MakeDamage(Collider other);
}
