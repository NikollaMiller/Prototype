using UnityEngine;

public class SwordDamage : MonoBehaviour, IDamageble
{
    public float damage;

    public float Damage => damage;

    public void MakeDamage(Collider other)
    {
        IHealth health = other.GetComponent<IHealth>();
        if (health != null)
        {
            if (health.m_ItsBossIndex == 1)
            {

            } 
            else
            {
                health.TakeDamage(Damage);
            }
        }
    }
}
