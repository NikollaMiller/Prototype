using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    private IDamageble m_Damagemaker;

    private void Start()
    {
        m_Damagemaker = GetComponent<IDamageble>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_Damagemaker.MakeDamage(other);
    }
}
