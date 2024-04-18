using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using static UnityEngine.Mathf;
public static class LibFunctions
{

    //public delegate float Function(float pos, float z, float time, float periodicity, float amplitude);
    public delegate Vector3 Function(float u, float v, float time);

    public enum FunctionName {Wave, MultiWave, Ripple, Sphere};
    static Function[] functions ={
                                    Wave,
                                    MultiWave,
                                    Ripple,
                                    Sphere
                                    };

    public static Function Func(FunctionName name)
    {
        return functions[(int)name];
    }

    //Single sine wave function
    public static Vector3 Wave(float u, float v, float time)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + time));
        p.z = v;

        return p;
    }



    //Multiple sine wave function
    public static Vector3 MultiWave(float u, float v, float time)
    {
        Vector3 p;

        p.x = u;

        p.y = Sin(PI * (u + 0.5f * time));
        p.y += 0.5f * Sin(2f * PI * (v + time));
        p.y += Sin(PI * (u + v + 0.25f + time));
        p.y *= (1f / 2.5f);

        p.z = v;

        return p;
    }

    //Ripple wave function
    public static Vector3 Ripple(float u, float v, float time)
    {
        Vector3 p;
        p.x = u;
        
        float d = Sqrt(u * u + v * v);
        p.y = Sin(PI * (4f * v * d - time));
        p.y /= (1f + 5f * d);
        
        p.z = v;

        return p;
    }

    // Sphere function
    public static Vector3 Sphere(float u, float v, float time)
    {
        Vector3 p;
        float r = 0.9f + 0.1f * Sin(PI * (6 * u + 4 * v + time));
        float s = r * Cos(0.5f * PI * v);
        
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * 0.5f * v);
        p.z = s * Cos(PI * u);
        
        return p;
    }

    ////Single sine wave function
    //public static float Wave(float pos, float z, float time, float periodicity, float amplitude)
    //{
    //    return amplitude * Sin(periodicity * (pos + z + time));
    //}



    ////Multiple sine wave function
    //public static float MultiWave(float pos, float z, float time, float periodicity, float amplitude)
    //{
    //    float y = Sin(PI * (pos + time));
    //    y += 0.5f * Sin(2f * (pos + z + time));
    //    y += amplitude * Sin(periodicity * (pos + z + 0.25f + time));
    //    return y * (1f / 2.5f);
    //}

    ////Ripple wave function
    //public static float Ripple(float pos, float z, float time, float periodicity, float amplitude)
    //{
    //    float d = Sqrt(pos * pos + z * z);
    //    float y = amplitude * Sin(periodicity * (4f * z * d - time));

    //    return y / (1f + 5f * d);
    //}
}
