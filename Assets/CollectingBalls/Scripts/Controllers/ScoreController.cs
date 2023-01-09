using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text _scoreResult;

    private void Update()
    {
        _scoreResult.text = "Ваш результат: " +  MeteoriteCounter._meteorite;
    }
}
