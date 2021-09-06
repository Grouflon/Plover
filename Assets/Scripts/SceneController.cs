using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AnimationController ploverAnimationController;
    public ParallaxController parallaxController;

    public void playPloverAnimation(string _animationName)
    {
        ploverAnimationController.playAnimation(_animationName);
    }

    public void setParallaxSpeed(float _speed)
    {
        parallaxController.speed = _speed;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
