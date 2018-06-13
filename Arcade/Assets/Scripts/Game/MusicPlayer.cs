using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
	[SerializeField]
	AudioClip[] _audioClips;

	AudioSource _thisAudioSource;

	void Awake()
	{
		_thisAudioSource = GetComponent<AudioSource>();

		if (_audioClips.Length == 0)
			return;

		var trackIndex = Random.Range(0, _audioClips.Length);
		_thisAudioSource.clip = _audioClips[trackIndex];
		_thisAudioSource.Play();
	}
}
