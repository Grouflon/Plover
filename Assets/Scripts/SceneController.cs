using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AnimationController ploverAnimationController;
    public ParallaxController parallaxController;
    public GameManager gameManager;

    public void playPloverAnimation(string _animationName)
    {
        ploverAnimationController.playAnimation(_animationName);
    }

    public void setParallaxSpeed(float _speed)
    {
        parallaxController.speed = _speed;
    }

    public void fadeSound(string _name, float _target, float _time)
    {
        gameManager.fadeSound(_name, _target, _time);
    }

    public void fadeDayIn(float _time)
    {
        gameManager.fadeSound("day", 1.0f, _time);
    }
    public void fadeDayOut(float _time)
    {
        gameManager.fadeSound("day", 0.0f, _time);
    }
    public void fadeNightIn(float _time)
    {
        gameManager.fadeSound("night", 1.0f, _time);
    }
    public void fadeNightOut(float _time)
    {
        gameManager.fadeSound("night", 0.0f, _time);
    }
    public void fadeFootstepsIn(float _time)
    {
        gameManager.fadeSound("footsteps", 1.0f, _time);
    }
    public void fadeFootstepsOut(float _time)
    {
        gameManager.fadeSound("footsteps", 0.0f, _time);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
