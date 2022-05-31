using UnityEngine;

public class ObjectsFollow : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private Vector3 m_Offset;
    [SerializeField] private float m_Smooth;

    private Transform m_Transform;

/*    private void Start()
    {
        m_Transform = GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        if (m_Target!=null)
        {
            m_Transform.position = Vector3.Lerp(m_Transform.position,m_Target.position + m_Offset,m_Smooth * Time.deltaTime);
        }
    }*/
}
