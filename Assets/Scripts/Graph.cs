using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform prefabPoint;                         // Placeholder for getting the spawn position
    int resolution = 100;                // Number of cubes to be spawned
    //[SerializeField, Range(1, 20)] int power;                     // Number of cubes to be spawned
    [SerializeField, Range(0, 1.5f)] float amplitude;                 // Number of cubes to be spawned
    [SerializeField, Range(0, 5)] float periodicity;             // Number of cubes to be spawned

    [SerializeField] LibFunctions.FunctionName FuncName;            // Use Multiple function

    Transform[] points;

    private void Awake()
    {
        points = new Transform[resolution * resolution];
        Transform point;                                            // Placeholder for the position of the prefab spawn position
        float step = 2f / resolution;                               // Constant value to increment position and keep the scale same
                                                                    // of prefab 
        Vector3 scale = Vector3.one * step, pos = Vector3.zero;

        for (int i = 0; i < points.Length; i++)
        {
            point = points[i] = Instantiate(prefabPoint);
        
            point.localScale = scale;
            point.SetParent(transform, false);
        }


        //for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        //{
        //    if (x == resolution)
        //    {
        //        x = 0;
        //        z++;
        //    }
        //    point = points[i] = Instantiate(prefabPoint);           // Creating prefab and getting its position
        //    point.SetParent(transform);                             // Setting its parent to 'this' GameObject

        //    pos.x = (x + 0.5f) * step - 1f;                         // Setting x position
        //    pos.z = (z + 0.5f) * step - 1f;                         // Setting z position

        //    point.localPosition = pos;                              // Setting prefab's position
        //    point.localScale = scale;                               // Setting prefab's scale
        //}
    }
    // Update is called once per frame
    void Update()
    {
        LibFunctions.Function f = LibFunctions.Func(FuncName);          // Creating delegate variable to store function
        ChangeGraph(f);                                             // Passing the delegate function according to the user's choice
    }

    private void ChangeGraph(LibFunctions.Function f)
    {
        float t = Time.time;                                        // Storing the time at the beginning of the frame when rendered

        float step = 2f / resolution;
        
        float v = 0.5f * step - 1f;                                 // Setting z position
        for (int i = 0,x = 0, z = 0; i < points.Length; i++, x++)   // Changing all the x positions of points
        {
            if(x == resolution)
            {
                x = 0;
                z++;
                v = (z + 0.5f) * step - 1f;                         // Setting z position

            }

            //Transform point = points[i];

            //Vector3 pos = point.localPosition;                      // Getting the local position of the point
            //pos.y = f(pos.x, pos.z, t);                             // Changing the y position of the point

            float u = (x + 0.5f) * step - 1f;                         // Setting x position

            points[i].localPosition = f(u, v, t);                     // Changing the overall position of the point
        }
    }
}
