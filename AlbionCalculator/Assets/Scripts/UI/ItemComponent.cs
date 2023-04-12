using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemComponent:MonoBehaviour
    {

        public Action OnClickDel;
        public Action OnClickRun;

        private Button delBtn;
        private Button runBtn;
        private Dropdown dropdown;
        private InputField inputField;

        private int level = 2;
        private int count = 0;
        private void Awake()
        {
            runBtn = transform.Find("Run").GetComponent<Button>();
            runBtn.onClick.AddListener(OnClickRunBtn);

            delBtn = transform.Find("Del").GetComponent<Button>();
            delBtn.onClick.AddListener(OnClickDelBtn);
            
            dropdown =transform.Find("Dropdown").GetComponent<Dropdown>();
            dropdown.onValueChanged.AddListener(OnValueChanged);
            
            inputField = transform.Find("InputField").GetComponent<InputField>();
            inputField.onValueChanged.AddListener(OnCountValueChanged);

        }

        private void OnClickRunBtn()
        {
            OnClickRun?.Invoke();
        }

        private void OnCountValueChanged(string arg0)
        {
            if (int.TryParse(arg0, out int result))
            {
                count = result;
            }
            else
            {
                inputField.text = "";
            }
        }

        private void OnValueChanged(int arg0)
        {
            level = arg0+2; // start with level2
        }

        private void OnClickDelBtn()
        {
            OnClickDel?.Invoke();
        }

        public (int,int) GetValue()
        {
            return (level,count);
        }
    }
}