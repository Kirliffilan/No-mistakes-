using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    [SerializeField] private VolumeKeeper _volumeKeeper;
    [SerializeField] private Slider _musicSlider; //слайдер дл€ музыки
    [SerializeField] private Slider _voiceSlider; //слайдер дл€ звуков

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
        VolumeApplier.UpdateVolume();
    }

    private void ChangeMusic(float value) //мен€ет громкость музыки
    {
        PlayerPrefs.SetFloat(MUSIC, value); //обновл€ет значени€
        _volumeKeeper.musicVolume = value;
        VolumeApplier.UpdateVolume(); //примен€ет громкость
    }

    private void ChangeVoice(float value) //мен€ет громкость звуков
    {
        PlayerPrefs.SetFloat(VOICE, value);//обновл€ет значени€
        _volumeKeeper.voiceVolume = value;
        VolumeApplier.UpdateVolume(); //примен€ет громкость
    }

    private void OnDisable() //сохран€ет значени€
    {
        PlayerPrefs.Save();
    }
}
