using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private Animator _animator;
    private AudioSource[] _audioSources;

    private const string Entered = "Entered";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSources = GetComponents<AudioSource>();
    }

    private IEnumerator ChengesVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            if (_audioSources[0].isPlaying)
            {
                _audioSources[1].volume += Time.deltaTime;

                if (_audioSources[1].volume == 1)
                    isWork = false;
            }
            else if (_audioSources[0].isPlaying  == false)
            {
                _audioSources[1].volume -= Time.deltaTime;

                if (_audioSources[1].volume == 0)
                {
                    _audioSources[1].Stop();
                    isWork = false;
                }
            }
            
            yield return null;
        }

        StopCoroutine(ChengesVolume());
    }

    public void TurnOnAlarm()
    {
        _animator.SetBool(Entered, true);

        foreach (var audioSorce in _audioSources)
        {
            audioSorce.Play();
        }

        StartCoroutine(ChengesVolume());
    }

    public void TurnOffAlarm()
    {
        _animator.SetBool(Entered, false);

        _audioSources[0].Stop();

        StartCoroutine(ChengesVolume());
    }
}