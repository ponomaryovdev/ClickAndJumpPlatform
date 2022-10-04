using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVelocity : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToPoint(Transform target)
    {
        rb.velocity = CalculateBalisticVelocity(transform.position, target.position, 60);
    }

    private Vector3 CalculateBalisticVelocity(Vector3 initialPos, Vector3 finalPos, float angle)
    {
        var toPos = initialPos - finalPos;

        var height = toPos.y;

        toPos.y = 0;
        var distance = toPos.magnitude;

        var gravity = -Physics.gravity.y;

        var acceleration = Mathf.Deg2Rad * angle;

        var newVelocity = Mathf.Sqrt(((Mathf.Pow(distance, 2f) * gravity)) / (distance * Mathf.Sin(2f * acceleration) + 2f * height * Mathf.Pow(Mathf.Cos(acceleration), 2f)));

        Vector3 velocity = (finalPos - initialPos).normalized * Mathf.Cos(acceleration);
        velocity.y = Mathf.Sin(acceleration);

        return velocity * newVelocity;
    }
}
