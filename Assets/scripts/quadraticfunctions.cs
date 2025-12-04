public class ParabolaFunction
{
    private float a, b, c;

    public ParabolaFunction(float a, float b, float c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public float CalculateY(float x)
    {
        return a * x * x + b * x + c;
    }
}
