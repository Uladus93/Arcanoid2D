using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private const float StandartWidht = 1080f;
    private const float StandartHeight = 2400f;
    private float _actualHeight;
    private float _actualWidth;
    private const float HalfOfStandartHeightInPixels = 200f;
    [SerializeField] private bool _isVertical = true;

    private void Awake()
    {
        CheckOrientation();
        CameraResize();
    }

    private void CameraResize()
    {
        float _screenWidht = Screen.width;
        float _screenHeight = Screen.height;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float standartRatio = _actualWidth / _actualHeight;

        if (screenRatio >= standartRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = standartRatio / screenRatio;
            Resize(differentSize);
        }

        void Resize(float differentSize = 1.0f)
        {
            Camera.main.orthographicSize = (_actualHeight / HalfOfStandartHeightInPixels) * differentSize;
        }
    }

    private void CheckOrientation()
    {
        _actualHeight = _isVertical ? StandartHeight : StandartWidht;
       _actualWidth = _isVertical ? StandartWidht : StandartHeight;
    }
}