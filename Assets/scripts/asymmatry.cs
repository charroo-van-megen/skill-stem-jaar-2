using UnityEngine;
using System;

public class QuadraticFunction : MonoBehaviour
{
    public float a;
    public float b;
    public float c;

    // Constructor vervangen door een Init-methode
    public void Init(float a, float b, float c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public float EvaluateValue(float t)
    {
        return (a * t * t) + (b * t) + c;
    }

    public Vector2 FindZero()
    {
        float D = (b * b) - (4f * a * c);

        if (D < 0f)
        {
            throw new InvalidOperationException("Geen reële oplossingen voor deze vergelijking.");
        }

        float sqrtD = Mathf.Sqrt(D);
        float denominator = 2f * a;

        float t1 = (-b + sqrtD) / denominator;
        float t2 = (-b - sqrtD) / denominator;

        return new Vector2(t1, t2);
    }
}
