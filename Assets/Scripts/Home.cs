using UnityEngine;

public class Home : MonoBehaviour
{
    private Animator _animator;
    private AudioSource[] _audioSources;

    private void Start()
    {
        _animator = GameObject.Find("Alarm").GetComponent<Animator>();
        _audioSources = GameObject.Find("Alarm").GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (_audioSources[0].isPlaying && _audioSources[1].volume < 1)
        {
            _audioSources[1].volume += Time.deltaTime;
        }

        if(_audioSources[0].isPlaying == false && _audioSources[1].volume > 0)
        {
            _audioSources[1].volume -= Time.deltaTime;

            if (_audioSources[1].isPlaying && _audioSources[1].volume <= 0)
            {
                _audioSources[1].Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("Alarm", true);

        foreach (var audioSorce in _audioSources)
        {
            audioSorce.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool("Alarm", false);

        _audioSources[0].Stop();
    }
}
