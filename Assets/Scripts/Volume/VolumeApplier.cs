using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeApplier : MonoBehaviour
{
    private static List<VolumeApplier> _all = new();

    [SerializeField] private VolumeKeeper _volumeKeeper;
    [SerializeField] private bool _isMusic = false;

    private AudioSource _audioSource;

    private void Awake()
    {
        _all.Add(this);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _isMusic ? _volumeKeeper.musicVolume : _volumeKeeper.voiceVolume;
    }

    private void OnDestroy()
    {
        _all.Remove(this);
    }

    public static void UpdateVolume()
    {
        foreach (var applier in _all)
        {
            applier._audioSource.volume = applier._isMusic ? applier._volumeKeeper.musicVolume : applier._volumeKeeper.voiceVolume;
        }
    }
}
