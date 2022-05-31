using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public float health;

    public float m_Health { get; set;}

    public int itsBossIndex = 0;

    public float m_ItsBossIndex => itsBossIndex;

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
        m_Health -= Damage;
        if (m_Health < 0)
        {
            Die();
        }
    }
}
