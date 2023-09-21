using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool _inProcesse = true;
    private SpriteRenderer _spriteRenderer;
    public bool InProcesse { get { return _inProcesse; } }
    private Rigidbody2D _rb2D;
    private float _speed = 10f;
    private const float BorderX = 4f;
    private const float BorderYMin = -11f;
    private const float BorderYMax = -2f;

    public float YMinPosition { get { return BorderYMin; }}

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public IEnumerator MoveObjectTo(float x, float y)
    {
        if (Mathf.Abs(Mathf.Round((_rb2D.position.x + x) * 100f) / 100f) > BorderX)
        {
            x = 0;
        }
        if (Mathf.Round((_rb2D.position.y + y) * 100f) / 100f < BorderYMin || Mathf.Round((_rb2D.position.y + y) * 100f) / 100f > BorderYMax)
        {
            y = 0;
        }
        if (gameObject.GetComponent<PlayerPanel>().FoilForPlayerPanel.Foil > 0) 
        {
            _inProcesse = false;
            Vector2 targetPosition = new Vector2(_rb2D.position.x + x, _rb2D.position.y + y);

            while (_rb2D.position != targetPosition)
            {
                float targetX = _rb2D.position.x + x * Time.fixedDeltaTime * _speed;
                float targetY = _rb2D.position.y + y * Time.fixedDeltaTime * _speed;
                targetX = Mathf.Clamp(targetX, -BorderX + (Mathf.Round(_spriteRenderer.size.x * transform.localScale.x) / 2),
                    BorderX - (Mathf.Round(_spriteRenderer.size.x * transform.localScale.x) / 2)); // - мне не падабаецца залежнасць кода ад памера спрайта.
                targetY = Mathf.Clamp(targetY, BorderYMin, BorderYMax);
                _rb2D.MovePosition(new Vector2(targetX, targetY));
                Vector2 direction = targetPosition - _rb2D.position;
                float distance = direction.magnitude;
                if (distance < 0.1f)
                {
                    transform.position = targetPosition;
                }
                yield return null;
            }

            if (x != 0 || y != 0)
            {
                gameObject.GetComponent<PlayerPanel>().FoilForPlayerPanel.FoilLess();
            }
            _inProcesse = true;
        }
    }
}