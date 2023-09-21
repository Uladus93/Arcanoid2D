using UnityEngine;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] BricksGenerator _bricksGenerator;
    [SerializeField] LevelComplete _levelComplete;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _mainMenu;
    public void LoadNextLevel()
    {
        _player.transform.position = new Vector3(0, -10, _player.transform.position.z);
        _ball.transform.position = new Vector3(0, -9, _ball.transform.position.z);
        _player.GetComponent<PlayerPanel>().NewLifesAndFoil();
        if (_bricksGenerator.NumberOfLevel + 1 <= _levelComplete.HowManyLevels)
        {
            _bricksGenerator.LoadLevel(_bricksGenerator.NumberOfLevel + 1);
            _ball.SetActive(true);
        }
        else
        {
            _mainMenu.SetActive(true);
        }
    }
}
