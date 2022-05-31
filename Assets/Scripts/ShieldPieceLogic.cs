using UnityEngine;

public class ShieldPieceLogic : MonoBehaviour
{
    public Vector3 m_ToPosition;

    private Transform m_Transform;

    private Transform m_Target;

    private RotateArounder m_RotateArounder;

    public float TimeAttack;

    private float time;

    private Vector3 m_Scaler;

    private bool m_Running;

    private bool m_Attack;

    private float imer;

    public float attackGo;

    private void Start()
    {
        m_Running = false;
        m_Transform = GetComponent<Transform>();
        m_Target = FindObjectOfType<AttacksVariants>().transform;
        m_RotateArounder = GetComponent<RotateArounder>();
        if (m_Transform.position.x > 0)
        {
            m_ToPosition = new Vector3(m_Transform.position.x + 2, m_Transform.position.y + 5, m_Transform.position.z + 15);
        }
        else 
        {
            m_ToPosition = new Vector3(m_Transform.position.x - 2, m_Transform.position.y + 5, m_Transform.position.z + 15);
        }
        m_Scaler = transform.parent.localScale + new Vector3(0.25f, 0.25f, 0.25f);
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        imer += Time.deltaTime;
        if (imer >= attackGo)
        {
            m_Attack = true;
        }

        if (m_Attack)
        {
            if (m_Transform.position != m_ToPosition && !m_Running)
            {
                m_RotateArounder.enabled = false;
                m_Transform.position = Vector3.MoveTowards(m_Transform.position, m_ToPosition, 5 * Time.deltaTime);
            }
            else
            {

                time += Time.deltaTime;
                if (time >= TimeAttack)
                {
                    m_Running = true;
                }
            }

            if (m_Running)
            {

                Attack();
            }

            if (transform.parent.localScale != m_Scaler)
            {
                transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, m_Scaler, 3 * Time.deltaTime);

            }

            if (m_Transform.rotation != Quaternion.Euler(90, 0, 0))
            {
                m_Transform.rotation = Quaternion.Lerp(m_Transform.rotation, Quaternion.Euler(90, 0, 0), 6 * Time.deltaTime);

            }
        }
    }

    private void Attack() 
    {
        if (m_Transform.position != m_Target.position)
        {
            
            m_Transform.position = Vector3.MoveTowards(m_Transform.position, m_Target.position, 100 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerOnObjects(other);
    }

    private void TriggerOnObjects(Collider other)
    {
        AttacksVariants player = other.GetComponent<AttacksVariants>();
        if (player != null)
            Destroy(this.gameObject);
    }
}
