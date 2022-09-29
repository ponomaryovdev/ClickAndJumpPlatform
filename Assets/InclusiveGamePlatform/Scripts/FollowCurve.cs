using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    public AnimationCurve XCurve;
    public AnimationCurve YCurve;
    public float Speed = 1;

    private Rigidbody2D _rigidbody;
    private float _timeElapsed = 0;
    private bool startFollow = false;
    private Vector2 startPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(!startFollow)
        {
            startFollow = true;
            _timeElapsed = 0;
            startPosition = transform.position;
        }
        else
        {
            _timeElapsed += Speed * Time.deltaTime;

            _rigidbody.MovePosition(new Vector2(
                startPosition.x + XCurve.Evaluate(_timeElapsed),
                startPosition.y + YCurve.Evaluate(_timeElapsed)
                ));
        }
    }

    public void StartFollow()
    {
        startFollow = true;
    }
}
