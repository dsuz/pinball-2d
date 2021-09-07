using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] float m_speed = 1000;
    HingeJoint2D m_joint = default;
    int m_fingerId = -1;

    void Start()
    {
        m_joint = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        ControlWithKeyboard();
        ControlWithTouch();
    }

    void SetAngle(float speed)
    {
        var motor = m_joint.motor;
        motor.motorSpeed = speed;
        m_joint.motor = motor;
    }

    void ControlWithTouch()
    {
        if (Input.touchCount < 0) return;

        foreach (var t in Input.touches)
        {
            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x < Screen.width / 2 && this.tag == "LeftFlipper")
                    {
                        m_fingerId = t.fingerId;
                        SetAngle(-1 * m_speed);
                    }
                    else if (t.position.x > Screen.width / 2 && this.tag == "RightFlipper")
                    {
                        m_fingerId = t.fingerId;
                        SetAngle(m_speed);
                    }

                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    if (t.fingerId == m_fingerId)
                    {
                        if (this.tag == "LeftFlipper")
                        {
                            SetAngle(m_speed);
                        }
                        else if (this.tag == "RightFlipper")
                        {
                            SetAngle(-1 * m_speed);
                        }

                        m_fingerId = -1;
                    }

                    break;
            }
        }
    }

    void ControlWithKeyboard()
    {
        if (this.tag == "LeftFlipper")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetAngle(-1 * m_speed);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                SetAngle(m_speed);
            }
        }
        else if (this.tag == "RightFlipper")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetAngle(m_speed);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                SetAngle(-1 * m_speed);
            }
        }
    }
}
