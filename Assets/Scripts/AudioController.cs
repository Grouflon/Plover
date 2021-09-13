using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public bool randomize = false;
    public float randomPitchAmplitude = 0.1f;

    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (randomize)
        {
            m_audioSource.loop = false;
        }
    }

    void Update()
    {
        if (m_isFading)
        {
            m_timer += Time.deltaTime;
            float t = m_timer / m_fadeTime;
            float volume = Mathf.Lerp(m_sourceVolume, m_targetVolume, m_timer / m_fadeTime);
            m_audioSource.volume = volume;

            if (t >= 1.0f)
            {
                m_isFading = false;
                m_audioSource.volume = m_targetVolume;
            }
        }

        if (randomize && !m_audioSource.isPlaying)
        {
            m_audioSource.pitch = 1.0f + Random.Range(-randomPitchAmplitude, randomPitchAmplitude);
            m_audioSource.Play();
        }
    }

    public void fadeAudio(float _target, float _time)
    {
        if (_time == 0.0f)
        {
            m_isFading = false;
            m_audioSource.volume = _target;
        }
        else
        {
            m_isFading = true;
            m_sourceVolume = m_audioSource.volume;
            m_targetVolume = _target;
            m_fadeTime = _time;
            m_timer = 0.0f;
        }
    }

    bool m_isFading = false;
    float m_sourceVolume = 0.0f;
    float m_targetVolume = 0.0f;
    float m_timer = 0.0f;
    float m_fadeTime = 0.0f;

    AudioSource m_audioSource;
}
