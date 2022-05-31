using UnityEngine;

public interface IHealth
{
    public float m_Health { get; set; }
    public float m_ItsBossIndex { get; }
    public void TakeDamage(float Damage);
    public void Die();
    public void SetHealth(float Health);
}
