using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private PlayerPanel _playerPanel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BallMoved>(out BallMoved ball))
        {
            _playerPanel.LifesOfPlayer.LifeLess();
            if (_playerPanel.LifesOfPlayer.Lifes < 1)
            {
                gameObject.GetComponent<GameOver>().GameIsOver();
            }
        }
        
    }
}