using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AssetCalculator
{
    public Dictionary<int, Func<int,float,int[], int[]>> funcDic;

    public AssetCalculator()
    {
        Init();
    }

    public void Init()
    {

        funcDic= new Dictionary<int, Func<int,float,int[],int[]>>()
        {
            {2,GetL2},
            {3,GetL3},
            {4,GetL4},
            {5,GetL5},
            {6,GetL6},
            {7,GetL7},
            {8,GetL8},
        };
    }

    int[] GetResult(int level)
    {
        int[] result = new int[level];
        for (var i = 0; i < result.Length; i++)
            result[i] = 0;
        return result;
    }
    
    void DebugResult(int level,int count, int[] result)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"target{level} count{count}\t");
        for (var i = 0; i < result.Length; i++)
        {
            sb.Append($"level {i+1} : {result[i]}\t");
        }
        Debug.Log(sb.ToString());
    }
    
     
    public int[] Calculator(int level,int count,float rate =0)
    {
        if (level==1)
        {
            return new int[1] { count };
        }
        
        var func = funcDic[level];
        int[] result = GetResult(level);
        float trueRate = 1 - rate;
        result = func(count,trueRate,result);
        DebugResult(level,count,result);
        return result;
    }

    public int[] MergerCalculator(List<int[]> data)
    {
        int maxLength = 0;
        foreach (int[] ints in data)
        {
            if (ints.Length > maxLength)
                maxLength = ints.Length;
        }

        int[] value = new int[maxLength];
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                value[j] += data[i][j];
            }
        }

        return value;
    }


    int[] GetL2(int x2,float rate,int[] result)
    {
        result[1] += Mathf.FloorToInt(x2*rate);
        return result;
    }

    int[] GetL3(int x3,float rate,int[] result)
    {
        result = GetL2(x3,rate,result);
        result[2]+=Mathf.FloorToInt(x3*rate);;
        return result;
    }
    
    int[] GetL4(int x4,float rate,int[] result)
    {
        result = GetL3(x4,rate,result);
        result[3] +=Mathf.FloorToInt(x4*2*rate);
        return result;
    }
    
    int[] GetL5(int x5,float rate,int[] result)
    {
        result = GetL4(x5,rate,result);
        result[4]+=Mathf.FloorToInt(x5*3*rate);;
        return result;
    }
    
    int[] GetL6(int x6,float rate,int[] result)
    {
        result = GetL5(x6,rate,result);
        result[5]+=Mathf.FloorToInt(x6*4*rate);
        return result;
    }
    
    int[] GetL7(int x7,float rate,int[] result)
    {
        result = GetL6(x7,rate, result);
        result[6] +=Mathf.FloorToInt(x7 * 5*rate); 
        return result;
    }
    
    int[] GetL8(int x8,float rate,int[] result)
    {
        result = GetL7(x8, rate,result);
        result[7]+=Mathf.FloorToInt(x8*6*rate);
        return result;
    }
}
