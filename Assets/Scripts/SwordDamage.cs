using UnityEngine;

public class SwordDamage : MonoBehaviour, IDamageble
{
    public float Damage => 1;

    public void MakeDamage(Collider other)
    {
        IHealth health = other.GetComponent<IHealth>();
        if (health != null)
        {
            health.TakeDamage(Damage);
        }
    }
}
