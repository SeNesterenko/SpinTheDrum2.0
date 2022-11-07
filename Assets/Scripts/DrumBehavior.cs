using UnityEngine;

public class DrumBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity = 60f;

    private int _direction = 1;
    private bool _isMoving;
    private HingeJoint _hingeJoint;
    private JointMotor _motor;
    
    private void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _motor = _hingeJoint.motor;
    }

    public void StartMove()
    {
        _isMoving = true;
        _motor.targetVelocity = _velocity * _direction;
        _hingeJoint.motor = _motor;
    }

    public void StopMove()
    {
        _isMoving = false;
        _motor.targetVelocity = 0;
        _hingeJoint.motor = _motor;
    }

    public void ReverseDirection()
    {
        _direction *= -1;
        
        if (_isMoving)
        {
            StartMove();
        }
    }
}
