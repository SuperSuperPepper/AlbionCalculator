using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorController 
{
    private AssetCalculator calculator;
    private CalculatorView view;
    private List<int[]> levelList;
    
    private float rate=0;

    private int[] value;
    
    public CalculatorController(CalculatorView view)
    {
        this.view = view;
        calculator = new AssetCalculator();
    
    }

    public void OnClickAdd()
    {
       
    }

    public void OnClickRun()
    {
        List<int[]> results = new List<int[]>();
        var list =view.GetValue();
        foreach ((int, int) tuple in list)
        {
            var result = calculator.Calculator(tuple.Item1, tuple.Item2,rate);
            results.Add(result);
        }

        this.value = calculator.MergerCalculator(results);
        
        view.ShowResult(value);
    }

   public void OnClickRate(float rate)
    {
        this.rate = rate;
    }


   
}
