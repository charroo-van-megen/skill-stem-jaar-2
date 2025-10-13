using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class ParaboolDrawer : MonoBehaviour
{
    [Header("Parameters y = ax² + bx + c")]
    [SerializeField] float a = -1f;
    [SerializeField] float b = 0f;
    [SerializeField] float c = 0f;

    [Header("Instellingen")]
    [SerializeField] int resolution = 100;
    [SerializeField] float xMin = -5f;
    [SerializeField] float xMax = 5f;
    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = resolution;
        line.widthMultiplier = 0.05f;
        DrawParabola();
    }

    void Update()
    {
        DrawParabola();
    }

    void DrawParabola()
    {
        float step = (xMax - xMin) / (resolution - 1);

        for (int i = 0; i < resolution; i++)
        {
            float x = xMin + i * step;
            float y = a * x * x + b * x + c;
            line.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    // Event-handlers voor sliders (optioneel)
    public void SetA(float value) { a = value; }
    public void SetB(float value) { b = value; }
    public void SetC(float value) { c = value; }
}
