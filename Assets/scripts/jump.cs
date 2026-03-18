using UnityEngine;

public class Jump : MonoBehaviour
{
    private QuadraticFunction quadratic;

    void Awake()
    {
        // Get the QuadraticFunction component from the same GameObject
        quadratic = GetComponent<QuadraticFunction>();

        if (quadratic == null)
        {
            Debug.LogError("QuadraticFunction component missing!");
        }
    }

    void Start()
{
    quadratic.a = -4f;
    quadratic.b = 8f;
    quadratic.c = 0f;

    float valueAt1 = quadratic.EvaluateValue(1f);
    Vector2 zeros = quadratic.FindZero();

    Debug.Log("f(1) = " + valueAt1);
    Debug.Log("Zeros: " + zeros);
}

}
