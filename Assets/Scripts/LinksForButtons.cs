using UnityEngine;

public class LinksForButtons : MonoBehaviour
{
    [SerializeField] private GameObject _playerPanel;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _levelGenerator;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _scrollWiew;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _userName;
    [SerializeField] private GameObject _inputField;
    public GameObject PlayerPanel { get { return _playerPanel; } }
    public GameObject Ball { get { return _ball; } }
    public GameObject MainMenu { get { return _mainMenu; } }
    public GameObject LevelGenerator { get { return _levelGenerator; } }
    public GameObject Background { get { return _background; } }
    public GameObject ScrollWiew { get { return _scrollWiew; } }
    public GameObject PlayButton { get { return _playButton; } }
    public GameObject PauseButton { get { return _pauseButton; } }
    public GameObject UserName { get { return _userName; } }
    public GameObject InputField { get { return _inputField; } }
}