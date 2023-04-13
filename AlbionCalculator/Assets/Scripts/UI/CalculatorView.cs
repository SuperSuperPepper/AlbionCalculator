using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorView : MonoBehaviour
{
    public GameObject item;
    
    private Button addBtn;
    private Button runBtn;

    private InputField rateInput;

    private Transform content;
    private Text[] resultTexts;

    private CalculatorController _controller;


    private List<ItemComponent> _components;
    private void Awake()
    {
        _components = new List<ItemComponent>();
        _controller = new CalculatorController(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        addBtn = transform.Find("ToolBar/Add").GetComponent<Button>();
        runBtn = transform.Find("Output/Run").GetComponent<Button>();
        
        addBtn.onClick.AddListener(OnClickAdd);
        runBtn.onClick.AddListener(OnClickRun);
        
        content = transform.Find("Scroll View/Viewport/Content");
        
        
        rateInput = transform.Find("ToolBar/InputField").GetComponent<InputField>();
        rateInput.onValueChanged.AddListener(OnRateValueChanged);

        resultTexts = transform.Find("Output/Result/ResultText").GetComponentsInChildren<Text>();

        AddNewItem();
    }

    private void OnRateValueChanged(string arg0)
    {
        if (float.TryParse(arg0, out float result))
        {
            result = Math.Clamp(result, 0, 1);
            _controller.OnClickRate(result);
        }
        else
        {
            rateInput.text = "";
        }
    }

    private void OnClickRun()
    {
        _controller.OnClickRun();
    }

    private void OnClickAdd()
    {
        AddNewItem();
    }

    void AddNewItem()
    {
        GameObject itemInstance = GameObject.Instantiate(item, content);
        ItemComponent itemIns = itemInstance.GetComponent<ItemComponent>();
        itemIns.OnClickDel = () =>
        {
            _components.Remove(itemIns);
            Destroy(itemInstance.gameObject);
        };
        itemIns.OnClickRun = OnClickRun;
        _components.Add(itemIns);
    }
    
    

    public List<(int,int)> GetValue()
    {
        List<(int,int)> list = new List<(int,int)>();
        foreach (ItemComponent component in _components)
        {
            var value = component.GetValue();
            list.Add(value);
        }
        return list;
    }

    public void ShowResult(int[] value)
    {
        for (int i = 0; i < resultTexts.Length; i++)
        {
            resultTexts[i].text = "0";
        }
        
        for (int i = 0; i < value.Length; i++)
        {
            resultTexts[i].text = value[i].ToString();
        }
    }
}
