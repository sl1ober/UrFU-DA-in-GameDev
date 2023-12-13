using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
	public double[] input;
	public double output;
}

[System.Serializable]
public class TrainingModule
{
	public string moduleName;
	public TrainingSet[] trainingSets;
}

public class Perceptron : MonoBehaviour {

	[SerializeField] PerceptronVisualization visualization;
	public TrainingModule[] tm;
	double[] weights = {0,0};
	double bias = 0;
	double totalError = 0;

	double DotProductBias(double[] v1, double[] v2) 
	{
		if (v1 == null || v2 == null)
			return -1;
	 
		if (v1.Length != v2.Length)
			return -1;
	 
		double d = 0;
		for (int x = 0; x < v1.Length; x++)
		{
			d += v1[x] * v2[x];
		}

		d += bias;
	 
		return d;
	}

	double CalcOutput(TrainingSet ts)
	{
		double dp = DotProductBias(weights,ts.input);
		if(dp > 0) return (1);
		return (0);
	}

	void InitialiseWeights()
	{
		for(int i = 0; i < weights.Length; i++)
		{
			weights[i] = Random.Range(-1.0f,1.0f);
		}
		bias = Random.Range(-1.0f,1.0f);
	}

	void UpdateWeights(TrainingSet ts)
	{
		double error = ts.output - CalcOutput(ts);
		totalError += Mathf.Abs((float)error);
		for(int i = 0; i < weights.Length; i++)
		{			
			weights[i] = weights[i] + error*ts.input[i]; 
		}
		bias += error;
	}

	double CalcOutput(double i1, double i2)
	{
		double[] inp = new double[] {i1, i2};
		double dp = DotProductBias(weights,inp);
		if (dp > 0)
		{
            visualization.VisualizePerceptron(1);
            return (1);
		}
        visualization.VisualizePerceptron(0);
        return (0);
	}

	void Train(int epochs, TrainingModule tm)
	{
		InitialiseWeights();
		
		for(int e = 0; e < epochs; e++)
		{
			totalError = 0;
			foreach (var ts in tm.trainingSets)
			{
				UpdateWeights(ts);
				//Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B: " + bias);
			}
			Debug.Log("TOTAL ERROR: " + totalError);
		}
	}

	void Start () 
	{
		StartCoroutine(TestCoroutine());
    }

	private IEnumerator TestCoroutine()
	{
        foreach (var testModule in tm)
        {
            Debug.LogWarning("Training " + testModule.moduleName);
            Train(8, testModule);
            bool isTestsPassed = true;

            foreach (var test in testModule.trainingSets)
            {
                var output = CalcOutput(test.input[0], test.input[1]);
                Debug.Log($"Test {test.input[0]} {test.input[1]}: " + output);
                if (output != test.output) isTestsPassed = false;
            }
            if (isTestsPassed) Debug.Log("All tests passed successfully");
            else Debug.Log("Some tests failed");

			if (testModule == tm[tm.Length - 1]) break;
            yield return new WaitForSeconds(1.5f);
            Debug.Log("Нажмите любую кнопку, чтобы продолжить");
			yield return new WaitUntil(() => Input.anyKey);
        }
    }
	
	void Update ()
	{
		
	}
}
