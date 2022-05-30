using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform m_Target;

    private Transform m_Transform;

    private void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Transform.LookAt(m_Target);
    }
}
