using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLoseController : MonoBehaviour
{
    [SerializeField] GameObject _losePanel;

    public AudioSource BackgroundMusic;
    public AudioSource LoseSound;

    public static bool GameEnd = false;

    private void OnTriggerEnter(Collider other)
    {
        BackgroundMusic.Stop();
        LoseSound.Play();

        MeteoriteCounter._meteorite = 0;

        GameEnd = true;

        //other.transform.position = new Vector3(0, 0, 0);

        Cursor.visible = true;
        _losePanel.SetActive(true);

        Destroy(other.gameObject);
    }
}
