using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuController : MonoBehaviour
{
    public AudioSource _buttonSound;
 
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

    public void LeaderbordButton()
    {

    }

    public void MusicButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public static void ZeroingTheQuantityOfMeteors()
    {
        MeteoriteCounter._meteorite = 0;
    }

    public void PlaySoundClick()
    {
        _buttonSound.Play();
    }
}
