using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool alwaysRun = true;

    public void playAnimation(string _animationName)
    {
        if (!alwaysRun)
        {
            m_animator.enabled = true;
        }
        m_animator.Play(_animationName);
        m_waitingForAnimation = true;
        m_waitingForAnimationName = _animationName;
    }

    public bool isAnimationPlaying()
    {
        AnimatorStateInfo info = m_animator.GetCurrentAnimatorStateInfo(0);
        return m_waitingForAnimation || info.loop || info.normalizedTime <= 1.0 || m_animator.IsInTransition(0);
    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        if (!alwaysRun)
        {
            m_animator.enabled = false;
        }
    }

    void Update()
    {
        if (m_waitingForAnimation && m_animator.GetCurrentAnimatorStateInfo(0).IsName(m_waitingForAnimationName))
        {
            m_waitingForAnimation = false;
        }

        if (!alwaysRun && !isAnimationPlaying())
        {
            m_animator.enabled = false;
        }
    }

    Animator m_animator;
    bool m_waitingForAnimation = false;
    string m_waitingForAnimationName;
}
