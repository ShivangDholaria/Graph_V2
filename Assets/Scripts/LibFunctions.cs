using UnityEngine;
using static UnityEngine.Mathf;
public static class LibFunctions
{

    public delegate float Function(float pos, float z, float time, float periodicity, float amplitude);
    public enum FunctionName {Wave, MultiWave, Ripple};
    static Function[] functions ={
                                    Wave,
                                    MultiWave,
                                    Ripple
                                    };

    public static Function Func(FunctionName name)
    {
        return functions[(int)name];
    }
    
    //Single sine wave function
    public static float Wave(float pos, float z, float time, float periodicity, float amplitude)
    {
        return amplitude * Sin(periodicity * (pos + z + time));
    }



    //Multiple sine wave function
    public static float MultiWave(float pos, float z, float time, float periodicity, float amplitude)
    {
        float y = Sin(PI * (pos + time));
        y += 0.5f * Sin(2f * (pos + z + time));
        y += amplitude * Sin( periodicity * (pos + z + 0.25f + time));
        return y * (1f / 2.5f);
    }

    //Ripple wave function
    public static float Ripple(float pos, float z, float time, float periodicity, float amplitude)
    {
        float d = Sqrt(pos * pos + z * z);
        float y = amplitude * Sin(periodicity * (4f * z * d - time));

        return y / (1f + 5f * d);
    }
}
