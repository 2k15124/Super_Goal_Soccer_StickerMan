using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public DrawLine drawLine;
    public Rigidbody rb;
    public float kickForce = 10f;

    private void Awake()
    {
        drawLine = GameObject.FindGameObjectWithTag("LineController").GetComponent<DrawLine>();
        rb = GetComponent<Rigidbody>();
    }

    public IEnumerator MovementBall()
    {
        for (int i = 1; i < drawLine.linePositions.Count; i++)
        {
            Vector3 startPos = drawLine.linePositions[i - 1];
            Vector3 endPos = drawLine.linePositions[i];

            Vector3 direction = (endPos - startPos).normalized;
            Vector3 force = direction * kickForce;

            rb.AddForce(force, ForceMode.Impulse);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
