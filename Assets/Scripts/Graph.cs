using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform prefabPoint;                         // Placeholder for getting the spawn position
    [SerializeField, Range(10, 100)] int resolution;                // Number of cubes to be spawned
    //[SerializeField, Range(1, 20)] int power;                     // Number of cubes to be spawned
    [SerializeField, Range(-5, 5)] float amplitude;                 // Number of cubes to be spawned
    [SerializeField, Range(-20, 20)] float periodicity;             // Number of cubes to be spawned

    [SerializeField, Range(0, 10)] int functionChoice;                      // Use single wave or multi-wave

    Transform[] points;

    private void Awake()
    {
        points = new Transform[resolution];
        Transform point;                                            // Placeholder for the position of the prefab spawn position
        float step = 2f / resolution;                               // Constant value to increment position and keep the scale same
                                                                    // of prefab 
        Vector3 scale = Vector3.one * step, pos = Vector3.zero;

        for (int i = 0; i < points.Length; i++)
        {
            point = points[i] = Instantiate(prefabPoint);           // Creating prefab and getting its position
            point.SetParent(transform);                             // Setting its parent to 'this' GameObject

            pos.x = (i + 0.5f) * step - 1f;                         // Setting x position

            point.localPosition = pos;                              // Setting prefab's position
            point.localScale = scale;                               // Setting prefab's scale
        }
    }
    // Update is called once per frame
    void Update()
    {
        LibFunctions.Function f = LibFunctions.Func(functionChoice);          // Creating delegate variable to store function
        ChangeGraph(f);                                             // Passing the delegate function according to the user's choice
    }

    private void ChangeGraph(LibFunctions.Function f)
    {
        float t = Time.time;                                        // Storing the time at the beginning of the frame when rendered
        for (int i = 0; i < points.Length; i++)                     // Changing all the x positions of points
        {
            Transform point = points[i];

            Vector3 pos = point.localPosition;                      // Getting the local position of the point
            pos.y = f(pos.x, t);                                    // Changing the y position of the point
            point.localPosition = pos;                              // Changing the overall position of the point
        }
    }
}
