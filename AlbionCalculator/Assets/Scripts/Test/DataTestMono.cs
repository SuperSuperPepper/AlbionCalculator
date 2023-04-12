using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTestMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AssetCalculator calculator = new AssetCalculator();
        var re = calculator.Calculator(1, 10,1);
        re = calculator.Calculator(2, 10,0.4f);
        re = calculator.Calculator(3, 10,0.4f);
        re = calculator.Calculator(4, 10,0.4f);
        re = calculator.Calculator(5, 10,0.4f);
        re = calculator.Calculator(6, 10,0.4f);
        re = calculator.Calculator(7, 10,0.4f);
        re = calculator.Calculator(8, 10,0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
