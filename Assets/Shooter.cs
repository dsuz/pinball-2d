using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform m_shootPoint = default;
    [SerializeField] float m_shootPower = 10f;

    void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        var ball = GameObject.FindGameObjectWithTag("Player");
        ball.transform.position = m_shootPoint.position;

        var rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * m_shootPower, ForceMode2D.Impulse);
    }
}
