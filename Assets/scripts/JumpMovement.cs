using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    public QuadraticFunction quadratic;
    private float elapsedTime = 0f;
    private bool jumping = false;
    private float jumpDuration;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        quadratic.a = -4f;  // example
        quadratic.b = 8f;
        quadratic.c = 0f;

        // get the end of jump time
        Vector2 zeros = quadratic.FindZero();
        jumpDuration = Mathf.Max(zeros.x, zeros.y);
    }

    void Update()
    {
        if (jumping)
        {
            elapsedTime += Time.deltaTime;
            float y = quadratic.EvaluateValue(elapsedTime);

            // move player
            Vector3 pos = startPos;
            pos.y = startPos.y + y;
            transform.position = pos;

            if (elapsedTime >= jumpDuration)
            {
                jumping = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            // start jump
            elapsedTime = 0f;
            jumping = true;
        }
    }
}
