using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;
    private ObjectPool _pool;

    public void SetPool(ObjectPool pool)
    {
        _pool = pool;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            if (_pool != null)
            {
                _pool.Release(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Optional: if using trigger instead of collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
            _pool.Release(gameObject);
        }
    }
}
