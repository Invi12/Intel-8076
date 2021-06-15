using System;
using System.Collections.Generic;
using System.Windows.Forms;

// AX AH AL



public class Register
{
    public static List<object> registers = new List<object>();
    public const string avaliableCharacters = "ABCDEF0123456789";

    public string Name { get ; set; } 
    public string Value { get => GetValue(); set => SetValue(value); }
    public Subregister HighRegister { get; }
    public Subregister LowRegister  { get; }
    private TextBox TextBox { get; }
    public Register(string name, TextBox textBox, TextBox HighRegisterTextBox,TextBox LowRegisterTextBox )
    {

        Name = name;
        TextBox = textBox;
        HighRegister = new Subregister("H",this, HighRegisterTextBox);
        LowRegister = new Subregister("L",this, LowRegisterTextBox);

        registers.Add(this);
        registers.Add(HighRegister);
        registers.Add(LowRegister);

        UpdateDisplay();
    }

    private string GetValue()
    {
        return $"{HighRegister.Value}{LowRegister.Value}";
    }

    public class Subregister
    {
        public string Name { get; set; }
        public string Value { get => value; set => SetValue(value); }
        private string value = "00";
        private Register ParentRegister { get; }
        private TextBox TextBox { get; }

        public Subregister(string name, Register parentRegister, TextBox textBox)
        {
            TextBox = textBox;
            Name = name;
            ParentRegister = parentRegister;

            TextBox.TextChanged += TextBox_TextChanged;

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            SetValue(TextBox.Text);
        }

        private void SetValue(string newValue) {
            newValue = newValue.ToUpper();
            if (CheckRegisterValue(newValue, 2))
            {
                value = newValue;

                ParentRegister.UpdateDisplay();
            }
        }

        public override string ToString()
        {
            return $"{ParentRegister.Name}{Name}";
            
        }
    }

    public override string ToString()
    {
        return $"{Name}X";
    }

    public void Reset() {
        Value = "0000";
    }

    public void Random() {
        string newValue = "";
        for(int i = 0; i < 4; i++)
        {
            newValue += avaliableCharacters[new Random().Next(0, avaliableCharacters.Length)];
        }
        Value = newValue;
    }

    public static void Exchange(Register r1, Register r2) {
        string temp = r1.Value;
        r1.Value = r2.Value;
        r2.Value = temp;
    }
    public static void Exchange(Register.Subregister r1, Register.Subregister r2)
    {
        string temp = r1.Value;
        r1.Value = r2.Value;
        r2.Value = temp;
    }

    public static void Move(Register r1, Register r2) {
        r1.Value = r2.Value;
    }
    public static void Move(Register.Subregister r1, Register.Subregister r2)
    {
        r1.Value = r2.Value;
    }

    public static bool CheckRegisterValue(string value, int length) {
        if (value.Length != length)
            return false;

        foreach(char c in value)
        {
            if (!avaliableCharacters.Contains(c))
            {
                return false;
            }
        }

        return true;
    }

    private void SetValue(string newValue) {
        newValue = newValue.ToUpper();

        if (CheckRegisterValue(newValue, 4))
        {
            string hightValue = newValue.Substring(0, 2);
            string lowValue = newValue.Substring(2, 2);

            HighRegister.Value = hightValue;
            LowRegister.Value = lowValue;

            UpdateDisplay();
        }
    }
    public void UpdateDisplay()
    {
        TextBox.Text = Value;
    }
}


