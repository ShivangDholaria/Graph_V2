using UnityEngine;
using static UnityEngine.Mathf;
public static class LibFunctions 
{
    public delegate float Function(float pos, float time);

    public static Function Func(int idx)
    {
        switch(idx)
        {
            case 0:return Wave;
            case 1:return MultiWave;
            case 2:return Ripple;
            default: return null;
        }
    }
    
    //Single sine wave function
    public static float Wave(float pos, float time)
    {
        return Sin(PI * (pos + time));
    }



    //Multiple sine wave function
    public static float MultiWave(float pos, float time)
    {
        float y = Sin(PI * (pos + time));
        y += 0.5f * Sin(2f * PI * (pos + time));
        return y * (2f / 3f);
    }

    //Ripple wave function
    public static float Ripple(float pos, float time)
    {
        float d = Abs(pos);
        float y = Sin(PI * (4f * d - time));

        return y / (1f + 5f * d);
    }
}
