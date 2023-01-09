using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonGameController : MonoBehaviour
{
    public Sprite UnMuted;
    public Sprite Muted;

    public Image ToggleSprite;

    public AudioSource ButtonSound;
    public AudioMixerGroup Mixer;

    private void Start()
    {
        ToggleSprite.sprite = UnMuted;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }

    public static void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void PlayButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    public void MusicMute(bool enabled)
    {
        if (enabled)
            Mixer.audioMixer.SetFloat("MusicMute", 0);
        else
            Mixer.audioMixer.SetFloat("MusicMute", -80);
    }

    public static void StopGameTime()
    {
        Cursor.visible = true;
        Time.timeScale = 0.0f;
    }

    public static void ContinueGameTime()
    {
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

    public void ChangeSprite()
    {
        if (ToggleSprite.sprite == UnMuted)
        {
            ToggleSprite.sprite = Muted;
        }
        else
        {
            ToggleSprite.sprite = UnMuted;
        }
    }

    public void PlaySoundClick()
    {
        ButtonSound.Play();
    }

    public static void ZeroingTheQuantityOfMeteors()
    {
        MeteoriteCounter._meteorite = 0;
    }
}
