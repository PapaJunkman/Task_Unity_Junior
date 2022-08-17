using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _unitChangeVolume;

    private float _currentValueVolume;
    private Animator _animator;
    private AudioSource[] _audioSources;

    private const string Entered = "Entered";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSources = GetComponents<AudioSource>();
    }

    private IEnumerator ChangesVolume(float value)
    {
        bool isWork = true;

        while (isWork)
        {
            _currentValueVolume = _audioSources[1].volume;
            _audioSources[1].volume += value;

            if (_audioSources[1].volume == _currentValueVolume)
                isWork = false;

            yield return null;
        }

        if (_audioSources[0].isPlaying == false)
            _audioSources[1].Stop();

        StopCoroutine(ChangesVolume(value));
    }

    public void SetAlarmStat(bool isEntered)
    {
        _animator.SetBool(Entered, isEntered);

        if (isEntered)
        {
            foreach (var audioSorce in _audioSources)
            {
                audioSorce.Play();
            }

            StartCoroutine(ChangesVolume(_unitChangeVolume));
        }
        else
        {
            _audioSources[0].Stop();

            StartCoroutine(ChangesVolume(-_unitChangeVolume));
        }
    }
}