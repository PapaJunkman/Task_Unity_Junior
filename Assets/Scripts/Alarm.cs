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

    private IEnumerator IncreaseSound()
    {
        while (_audioSources[1].volume < 1)
        {
            _audioSources[1].volume += Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator ReduceSound()
    {
        while (_audioSources[1].volume > 0)
        {
            _audioSources[1].volume -= Time.deltaTime;

            yield return null;
        }

        _audioSources[1].Stop();

        StopCoroutine(ReduceSound());
    }

    public void TurnOnAlarm()
    {
        _animator.SetBool(Entered, true);

        foreach (var audioSorce in _audioSources)
        {
            audioSorce.Play();
        }

        StartCoroutine(IncreaseSound());
    }

    public void TurnOffAlarm()
    {
        _animator.SetBool(Entered, false);

        _audioSources[0].Stop();

        StopCoroutine(IncreaseSound());
        StartCoroutine(ReduceSound());
    }
}