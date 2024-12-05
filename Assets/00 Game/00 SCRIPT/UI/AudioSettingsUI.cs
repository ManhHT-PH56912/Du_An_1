using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [Header("--- UI Elements ---")]
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Slider sfxVolumeSlider;

    [System.Obsolete]
    private void Start()
    {
        // Đặt sự kiện cho UI
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxToggle.onValueChanged.AddListener(OnSFXToggleChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

        // Khởi tạo giá trị UI theo trạng thái AudioManager
        musicToggle.isOn = !AudioManager.Instance.MusicSource.mute;
        musicVolumeSlider.value = AudioManager.Instance.MusicSource.volume;
        sfxToggle.isOn = !AudioManager.Instance.SFXSource.mute;
        sfxVolumeSlider.value = AudioManager.Instance.SFXSource.volume;
    }

    [System.Obsolete]
    private void OnMusicToggleChanged(bool isOn)
    {
        AudioManager.Instance.ToggleMusic(isOn);
    }

    [System.Obsolete]
    private void OnMusicVolumeChanged(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }

    [System.Obsolete]
    private void OnSFXToggleChanged(bool isOn)
    {
        AudioManager.Instance.ToggleSFX(isOn);
    }

    [System.Obsolete]
    private void OnSFXVolumeChanged(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume);
    }
}
