using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField] float vbegin = 4f;   // beginsnelheid omhoog bij sprong
    [SerializeField] float g = -5f;       // zwaartekracht
    Animator animator;

    enum State { running, jumping };
    State myState = State.running;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    float tmax = 1.667f; // tijdsduur van jump-animatie
    float t = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (myState)
        {
            case State.running:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // Bereken zwaartekracht voor symmetrische sprong:
                    g = -2 * vbegin / tmax;

                    // Start sprong
                    myState = State.jumping;
                    t = 0;
                    velocity = new Vector3(0, vbegin, 0);
                    acceleration = new Vector3(0, g, 0);
                    animator.Play("jump");
                }
                break;

            case State.jumping:
                t += Time.deltaTime;
                velocity += acceleration * Time.deltaTime;
                transform.position += velocity * Time.deltaTime;

                if (t > tmax)
                {
                    // Reset naar grondniveau (Y=0 bijvoorbeeld)
                    var pos = transform.position;
                    pos.y = 0;
                    transform.position = pos;

                    myState = State.running;
                    animator.Play("run");
                }
                break;
        }
    }
}
