using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private static Animator m_Animator;

    private static string m_AnimatorKey = "CharacterState";

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;
    }

    public static void SetAnimation(int index) 
    {
        m_Animator.enabled = true;
        m_Animator.SetInteger(m_AnimatorKey, index);
    }
}
