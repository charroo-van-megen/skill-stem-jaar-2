using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Animator anim;

    [Header("Jump Parameters")]
    public float g = -10f;   // zwaartekracht
    public float v0 = 9f;    // beginsnelheid
    public float h0 = -3f;   // beginhoogte

    [Header("Animation Data")]
    public float animationTime = 0.75f;   // tijd van de spronganimatie

    private float jumpTime;  // berekende sprongduur

    private void Start()
    {
        // De quadratic functie van de sprong
        QuadraticFunction f = new QuadraticFunction(
            -0.5f * g,
            v0,
            h0
        );

        // Vind nulpunten
        Vector2 roots = f.FindZero();

        // Grootste is de totale sprongduur
        jumpTime = Mathf.Max(roots.x, roots.y);

        Debug.Log("Sprongduur = " + jumpTime + " seconden");

        // Animatiesnelheid
        float speed = animationTime / jumpTime;
        anim.speed = speed;

        Debug.Log("Animation speed ingesteld op: " + speed);
    }

    private void Update()
    {
        // Druk op spatie om de sprong te spelen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Jump", 0, 0f); 
        }
    }
}
