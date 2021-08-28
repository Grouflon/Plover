using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public AnimationController ploverAnimationController;

    public void playPloverAnimation(string _animationName)
    {
        ploverAnimationController.playAnimation(_animationName);
    }
}
