using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    [SerializeField] private VolumeKeeper _volumeKeeper;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _voiceSlider;

    private const string MUSIC = "Music";
    private const string VOICE = "Voice";

    private void Awake()
    {
        _volumeKeeper.musicVolume = PlayerPrefs.GetFloat(MUSIC, 0.3f);
        _volumeKeeper.voiceVolume = PlayerPrefs.GetFloat(VOICE, 0.7f);

        _musicSlider.value = _volumeKeeper.musicVolume;
        _voiceSlider.value = _volumeKeeper.voiceVolume;


        _musicSlider.onValueChanged.AddListener(ChangeMusic);
        _voiceSlider.onValueChanged.AddListener(ChangeVoice);
    }

    private void ChangeMusic(float value)
    {
        PlayerPrefs.SetFloat(MUSIC, value);
        _volumeKeeper.musicVolume = value;
        VolumeApplier.UpdateVolume();
    }

    private void ChangeVoice(float value)
    {
        PlayerPrefs.SetFloat(VOICE, value);
        _volumeKeeper.voiceVolume = value;
        VolumeApplier.UpdateVolume();
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}
