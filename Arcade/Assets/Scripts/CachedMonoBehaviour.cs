using UnityEngine;

public class CachedMonoBehaviour : MonoBehaviour
{
    Transform _thisTransform;

    public Transform cachedTransform
    {
        get
        {
            if (_thisTransform == null)
                _thisTransform = GetComponent<Transform>();

            return _thisTransform;
        }
    }

    Rigidbody _thisRigidbody;

    public Rigidbody cachedRigidbody
    {
        get
        {
            if (_thisRigidbody == null)
                _thisRigidbody = GetComponent<Rigidbody>();

            return _thisRigidbody;
        }
    }

    AudioSource _thisAudioSource;

    public AudioSource cachedAudioSource
    {
        get
        {
            if (_thisAudioSource == null)
                _thisAudioSource = GetComponent<AudioSource>();

            return _thisAudioSource;
        }
    }
}