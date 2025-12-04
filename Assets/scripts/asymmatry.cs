using UnityEngine;

public class QuadraticFunction
{
    public float a;
    public float b;
    public float c;

    // Constructor
    public QuadraticFunction(float a, float b, float c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Value of f(t)
    public float EvaluateValue(float t)
    {
        return (a * t * t) + (b * t) + c;
    }

    // Find the two zero points (roots)
    public Vector2 FindZero()
    {
        float D = (b * b) - (4 * a * c);

        if (D < 0)
            throw new System.InvalidOperationException("Geen reële oplossingen voor deze vergelijking.");

        float t1 = (-b + Mathf.Sqrt(D)) / (2 * a);
        float t2 = (-b - Mathf.Sqrt(D)) / (2 * a);

        return new Vector2(t1, t2);
    }
}
