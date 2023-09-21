using UnityEngine;
using UnityEngine.UI;

public class ReplayLevel : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] BricksGenerator _bricksGenerator;
    [SerializeField] Button _button;

    public void ReloadLevel()
    {
        _player.transform.position = new Vector3(0, -10, _player.transform.position.z);
        _ball.transform.position = new Vector3(0, -9, _ball.transform.position.z);
        _player.GetComponent<PlayerPanel>().NewLifesAndFoil();
        _bricksGenerator.LoadLevel(_bricksGenerator.NumberOfLevel);
    }
}
