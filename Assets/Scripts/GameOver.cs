using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _gameOverImage;

    public void GameIsOver()
    {
        _ball.SetActive(false);
        _gameOverImage.SetActive(true);
    }
}