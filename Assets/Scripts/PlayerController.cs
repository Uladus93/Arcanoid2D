using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControl _controls;

    private Vector2 _startSwipePosition;
    private Vector2 _endSwipePosition;
    private Vector2 _currentPosition => _controls.Touch.Move.ReadValue<Vector2>();
    private float _minSwipeLength;

    private void Awake()
    {
        _controls = new PlayerControl();
        _controls.Touch.Press.started += _ => { _startSwipePosition = _currentPosition; };
        _controls.Touch.Press.canceled += _ => { DetectSwipe(); };
    }

    private void Start()
    {
        _minSwipeLength = 100f;
    }

    private void OnEnable()
    {
        _controls.Touch.Enable();
    }

    private void OnDisable()
    {
        _controls.Touch.Disable() ;
    }

    private void DetectSwipe()
    {
        if (gameObject.GetComponent<Move>().InProcesse == true)
        {
            _endSwipePosition = _currentPosition;
            float deltaX = _endSwipePosition.x - _startSwipePosition.x;
            float deltaY = _endSwipePosition.y - _startSwipePosition.y;
            float x = SetCoordinate(deltaX);
            float y = SetCoordinate(deltaY);
            StartCoroutine( gameObject.GetComponent<Move>().MoveObjectTo(x, y));
            float SetCoordinate(float delta)
            {
                if (delta < -_minSwipeLength)
                {
                    return -1.5f;
                }
                else if (delta > _minSwipeLength)
                {
                    return 1.5f;
                }
                else { return 0f; }
            }
        } 
    }
}