using UnityEngine;

[CreateAssetMenu(fileName = "ColorManager", menuName = "ScriptableObjects", order = 0)]
public class ColorManager : ScriptableObject
{
    public Color A = Color.yellow;

    public Color B = Color.blue;

    public Color C = Color.green;

    public Color D = Color.white;

    public Color E = Color.magenta;

    public Color[] clrs = new Color[5];

    public Color nextColor(Color clr)
    {
        if (clr == A)
        {
            return B;
        }
        else if (clr == B)
        {
            return C;
        }
        else if (clr == C)
        {
            return D;
        }
        else if (clr == D)
        {
            return E;
        }
        else if (clr == E)
        {
            return A;
        }
        else
        {
            return A;
        }
    }
}