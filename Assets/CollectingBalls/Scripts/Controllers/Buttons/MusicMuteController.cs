using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicMuteController : MonoBehaviour
{
    public Sprite UnMuted;
    public Sprite Muted;

    public Toggle _muteOrUnmuteValue;

    public Image ToggleSprite;

    public AudioSource ButtonSound;
    public AudioMixerGroup Mixer;

    private bool _isMuted;    //0 - unMute, 1 - mute
    private static int _boolToSave;

    private void Start()
    {
        LoadGame();
    }

    public void MusicMute(bool enabled)
    {
        _isMuted = enabled;

        if (_isMuted)
        {
            Mixer.audioMixer.SetFloat("MusicMute", 0);
            _boolToSave = 1;
        }
        else
        {
            Mixer.audioMixer.SetFloat("MusicMute", -80);
            _boolToSave = 0;
        }

        SaveMusic();
    }

    public void ChangeSprite(bool enabled)
    {
        _isMuted = enabled;

        if (_isMuted)
        {
            ToggleSprite.sprite = UnMuted;
        }
        else
        {
            ToggleSprite.sprite = Muted;
        }
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetInt("SavedVoluem", _boolToSave );
        PlayerPrefs.Save();
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedVoluem"))
        {
            _boolToSave = PlayerPrefs.GetInt("SavedVoluem");

            if (_boolToSave == 1) _isMuted = true;
            else _isMuted = false;

            _muteOrUnmuteValue.isOn = _isMuted;

            if (_isMuted)
            {
                MusicMute(_isMuted);
                ChangeSprite(_isMuted);
            }
            else
            {
                MusicMute(_isMuted);
                ChangeSprite(_isMuted);
            }
        }
    }
}
