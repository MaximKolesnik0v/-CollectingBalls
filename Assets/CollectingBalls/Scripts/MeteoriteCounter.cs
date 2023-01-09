 using UnityEngine;
using UnityEngine.UI;

public class MeteoriteCounter : MonoBehaviour
{
    public AudioSource _dieSound;

    public Text text;
    public static int _meteorite = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Meteorite"))
        {
            _dieSound.Play();
            _meteorite++;
            text.text = "Собрано метеоритов: " + _meteorite.ToString();
            Destroy(collision.gameObject);
        }
    }
}
