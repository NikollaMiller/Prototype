using UnityEngine;

public class RotateArounder : MonoBehaviour
{
    private Transform m_Transform;

    [SerializeField] private Transform m_Target;

    private void Start()
    {
        m_Transform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if (m_Transform != null)
            m_Transform.RotateAround(m_Target.position,m_Transform.forward,60 * Time.deltaTime);
    }
}
