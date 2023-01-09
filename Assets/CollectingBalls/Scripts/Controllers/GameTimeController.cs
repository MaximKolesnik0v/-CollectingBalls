using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeController : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject _endgame;

    public AudioSource EndtimerSound;
    public AudioSource BackgroundMusic;
    public AudioSource WinMusic;

    private float _timeLeft = 0f;

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("Время до конца игры: {0:00} : {1:00}", minutes, seconds);
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft >= 10)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }

        if (_timeLeft > 0 & _timeLeft < 10) EndtimerSound.Play();

        while (_timeLeft > 0 & _timeLeft < 10)
        {
            UpdateTimeText();
            _timeLeft -= Time.deltaTime;
            yield return null;
        }

        if (_timeLeft <= 0 & ZoneLoseController.GameEnd != true)
        {
            EndtimerSound.Stop();
            BackgroundMusic.Stop();
            WinMusic.Play();

            _endgame.SetActive(true);
            ButtonGameController.StopGameTime();
            yield return null;
        }
    }
}