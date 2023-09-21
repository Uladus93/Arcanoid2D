using System;
using UnityEngine;
using UnityEngine.UI;

public class BrickLess : MonoBehaviour
{
    [SerializeField] private PlayerPanel _playerPanel;
    [SerializeField] private LevelComplete _levelComplete;
    [SerializeField] private GameObject _soundToggle;

    public void BrickLessOnOne()
    {
        _playerPanel.FoilUp();
        _levelComplete.LevelIsDone();
        if (_soundToggle.GetComponent<Toggle>().isOn)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}