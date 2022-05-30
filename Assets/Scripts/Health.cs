using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public float health;

    public float m_Health { get; set;}

    private void Start()
    {
        SetHealth(health);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void SetHealth(float Health)
    {
        m_Health = Health;
    }

    public void TakeDamage(float Damage)
    {
        
    }
}
