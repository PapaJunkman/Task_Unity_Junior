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
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Alarm") && _audioSources[1].volume < 1)
        {
            _audioSources[1].volume += Time.deltaTime;
        }
        else
        {
            _audioSources[1].volume -= Time.deltaTime;
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
