using UnityEngine;

public interface IHealth
{
    public float m_Health { get; set; }
    public void TakeDamage(float Damage);
    public void Die();
    public void SetHealth(float Health);
}
