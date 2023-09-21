using UnityEngine;

public class BallMoved : MonoBehaviour
{
    private Rigidbody2D _rb;
    private const float Force = 300f;
    private PhysicsMaterial2D _material;
    private float _maxSpeed;
    private float _lastPositionX;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _material = new PhysicsMaterial2D();
        _material.friction = 0;
        _material.bounciness = 1;
        _material.name = "BallMaterial2D";
        gameObject.GetComponent<Collider2D>().sharedMaterial = _material;
        _rb.sharedMaterial = _material;
        _rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        _maxSpeed = 10f;
        BallActivate();
    }

    private void BallActivate()
    {
        _lastPositionX = _rb.position.x;
        transform.SetParent(null);
        _rb.AddForce(Vector2.up * Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }

        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {

            float collisionPointX = collision.contacts[0].point.x;
            _rb.velocity = Vector2.zero;
            float playerCenterPosition = player.gameObject.GetComponent<Transform>().position.x;
            float difference = collisionPointX - playerCenterPosition;
            _rb.AddForce(new Vector2(difference * Force / 2, Force));
        }
    }
}
