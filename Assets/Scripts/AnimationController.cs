using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void playAnimation(string _animationName)
    {
        m_animator.Play(_animationName);
        m_waitingForAnimation = true;
        m_waitingForAnimationName = _animationName;
    }

    public bool isAnimationPlaying()
    {
        /*AnimatorStateInfo info = m_animator.GetCurrentAnimatorStateInfo(0);
        print(info.normalizedTime);*/
        return m_waitingForAnimation || m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0 || m_animator.IsInTransition(0);
    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (m_waitingForAnimation && m_animator.GetCurrentAnimatorStateInfo(0).IsName(m_waitingForAnimationName))
        {
            m_waitingForAnimation = false;
        }
    }

    Animator m_animator;
    bool m_waitingForAnimation = false;
    string m_waitingForAnimationName;
}
