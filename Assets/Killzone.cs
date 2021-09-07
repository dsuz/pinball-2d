using UnityEngine;
using UnityEngine.Events;

public class Killzone : MonoBehaviour
{
    [SerializeField] UnityEvent m_action = default;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_action.Invoke();
        }
    }
}
