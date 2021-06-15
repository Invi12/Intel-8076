using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architektura
{
    public partial class Form1 : Form
    {
        public object firstSelected, secondSelected;
        public Register AX, BX, CX, DX;
        public Form1()
        {
            InitializeComponent();
            IntializeRegisters();

        }
        private void IntializeRegisters()
        {
            AX = new Register("A",AXtextbox, AHtextbox, ALtextbox);
            BX = new Register("B",BXtextbox, BHtextbox, BLtextbox);
            CX = new Register("C",CXtextbox, CHtextbox, CLtextbox);
            DX = new Register("D",DXtextbox, DHtextbox, DLtextbox);

            FirstCombo.Items.AddRange(Register.registers.ToArray());
            SecondCombo.Items.AddRange(Register.registers.ToArray());
        }
        private void Alert(string message)
        {

        }

        private void Move_Click(object sender, EventArgs e)
        {
            if (FirstCombo.SelectedItem is Register && SecondCombo.SelectedItem is Register)
            {
                Register r1 = FirstCombo.SelectedItem as Register;
                Register r2 = SecondCombo.SelectedItem as Register;

                Register.Move(r1, r2);
            }
            else if (FirstCombo.SelectedItem is Register.Subregister && SecondCombo.SelectedItem is Register.Subregister)
            {
                Register.Subregister r1 = FirstCombo.SelectedItem as Register.Subregister;
                Register.Subregister r2 = SecondCombo.SelectedItem as Register.Subregister;

                Register.Move(r1, r2);
            }
            else
            {
                Alert("Proszę zaznaczyć odpowiednie rejestry!!!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exchange_Click(object sender, EventArgs e)
        {
            if (FirstCombo.SelectedItem is Register && SecondCombo.SelectedItem is Register)
            {
                Register r1 = FirstCombo.SelectedItem as Register;
                Register r2 = SecondCombo.SelectedItem as Register;





                Register.Exchange(r1, r2);
            }
            else if (FirstCombo.SelectedItem is Register.Subregister && SecondCombo.SelectedItem is Register.Subregister)
            {
                Register.Subregister r1 = FirstCombo.SelectedItem as Register.Subregister;
                Register.Subregister r2 = SecondCombo.SelectedItem as Register.Subregister;

                Register.Exchange(r1, r2);
            }
            else
            {
                Alert("Proszę zaznaczyć odpowiednie rejestry!!!");
            }
        }

        private void Random_Click(object sender, EventArgs e)
        {
            AX.Random();
            BX.Random();
            CX.Random();
            DX.Random();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            AX.Reset();
            BX.Reset();
            CX.Reset();
            DX.Reset();
        }

        private void AHtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BHtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CHtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DHtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ALtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BLtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
