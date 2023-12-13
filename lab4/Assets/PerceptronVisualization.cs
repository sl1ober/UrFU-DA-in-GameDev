using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptronVisualization : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    int cubeIndex;

    public void VisualizePerceptron(int value)
    {
        if (value == 0) ValueZero(cubes[cubeIndex]);
        else ValueOne(cubes[cubeIndex]);
        if (++cubeIndex >= cubes.Length) cubeIndex = 0;
    }

    private void ValueZero(GameObject cube)
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.red;
        cube.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
    }

    private void ValueOne(GameObject cube) 
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.green;
        cube.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500f, 0));
        cube.transform.localScale = new Vector3(1.4f,1.4f,1.4f);
    }
}
