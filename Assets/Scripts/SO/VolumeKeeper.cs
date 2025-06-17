using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "Settings/AudioSettings")]
public class VolumeKeeper : ScriptableObject
{
    [Range(0f, 1f)] public float musicVolume = 0.5f;
    [Range(0f, 1f)] public float voiceVolume = 0.7f;
}
