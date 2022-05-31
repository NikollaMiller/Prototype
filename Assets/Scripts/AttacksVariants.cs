using UnityEngine;

public class AttacksVariants : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    public int m_SelectAnimation;

    [SerializeField] private UserInput m_UserInput;

    public static bool m_Attack;

    private void Awake()
    {
        UserInput.Swiper += SetAnimationSwipe;
    }

    private void SetAnimationSwipe(int index) 
    {
        if (!m_Attack)
        {
            m_Animator.enabled = true;
            m_SelectAnimation = index;
            m_Animator.SetInteger("CharacterState", m_SelectAnimation);
            m_Attack = true;
            Invoke(nameof(OnTurnOnSwiper), 1.5f);
        }
    }

    private void OnTurnOnSwiper()
    {
        m_Animator.SetInteger("CharacterState", 0);
        m_Attack = false;
    }

    private void OnDestroy()
    {
        UserInput.Swiper -= SetAnimationSwipe;
    }
}
