using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace loopsnconditions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //button1.Location = new Point(1, 2);

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Thread.Sleep(1000);
            //sw.Stop();
            //int time = sw.Elapsed.Seconds;

            //MessageBox.Show("time: " + time);


        }

        #region short circuit

        /// <summary>
        /// Test condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (getcbox(comboBox1, label1).Equals("1")
                && getcbox(comboBox2, label2).Equals("1")
                && getcbox(comboBox3, label3).Equals("1"))
            {
                MessageBox.Show("they are all one");
            }
            else
            {
                MessageBox.Show("short circuit evaluation rules");
            }
        }

        private string getcbox(ComboBox cbox, Label lb)
        {
            MessageBox.Show("test");
            string returnVal = cbox.Text;
            lb.Text = returnVal;
            return returnVal;
        }

        #endregion


        #region mixed

        /// <summary>
        /// increment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {                      

            int a = 5, b = 0;
            b = ++a;
            MessageBox.Show("b is: " + b);

            a = 5;            
            b = a++;
            MessageBox.Show("b is then: " + b);

        }

        /// <summary>
        /// break
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            for ( i = 0; i < 100; i++)
            {
                if (textBox1.Text.Equals(i.ToString()))
                {
                    break;
                }
            }
            MessageBox.Show("I am done counting, I reached: "+i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i < 95)
                {
                    continue;
                }
                MessageBox.Show("counted to: "+i);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            Random random = new Random();
            while (true)
            {
                // Get a random number.
                int value = random.Next();
                // If number is divisible by two, continue.
                if ((value % 2) == 0)
                {
                    continue;
                }
                // If number is divisible by three, continue.
                if ((value % 3) == 0)
                {
                    continue;
                }
                Console.WriteLine("Not divisible by 2 or 3: {0}", value);
                // Pause.
                Thread.Sleep(100);
            }

        }

        #endregion 

        //---------------------------------------------------
        #region ref

        class ByValue
        {
            public int MyInt { get; set; }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            //int no = 20;
            //int no2 = 10;
            //increaseNo( ref no, ref no2);
            //MessageBox.Show("my number:"+no+" - " + no2);

            ByValue bv = new ByValue();
            bv.MyInt = 42;

            ChangeByValue(ref bv);
            MessageBox.Show("Caller" + bv.MyInt);
        }

        private void ChangeByValue( ref ByValue byValue)
        {
            MessageBox.Show("" + byValue.MyInt);
            byValue = new ByValue();
            byValue.MyInt = 99;
        }


        private void increaseNo( ref int myNo, ref int myNo2) {
            myNo = 40;
            myNo2 = 50;            
        }

        #endregion

        //---------------------------------------------------

        #region scope

        private int varI = 30 ;
        private void button7_Click(object sender, EventArgs e)
        {            

            int i;            
            for ( i = 0; i < 10; i++)
            {
                
                Console.WriteLine("my number"+i);
            }
            MessageBox.Show("my number:"+i);            
           
            int varI = 50;
            Console.WriteLine("varI:" + varI);            
        }

        private void Another() {
            int varI = 20;
            Console.WriteLine("varI1:" + varI);
        }

        #endregion

        #region out
        private void keyOut(object sender, EventArgs e)
        {
            int undefinedInt;
            int someInt;

            SetIntValue(out undefinedInt,out someInt);

            MessageBox.Show("value of undefinedInt:" + undefinedInt);

        }

        private void SetIntValue(out int definedInt, out int definedInt2)
        {
            definedInt = 10;
            definedInt2 = 20;
        }

        private void SetPrivateIntValue( int definedInt)
        {
            definedInt = 10;
        }
        #endregion



        private void button9_Click(object sender, EventArgs e)
        {
            int no = 5;

            

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(no++ * i);
            }
            Console.WriteLine(no);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RecursionCount(5,0);
        }

        private void RecursionCount(int n, int factor)
        {

            Console.WriteLine($"{n} * {factor} = {n * factor}");

            if (++factor <= 10)
                RecursionCount(n, factor);
        }
    }
}
