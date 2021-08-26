using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary_Division
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		//Функция суммы в прямых кодах положительных чисел
		static long Sum(long val1, long val2)
		{
			long i = 0, rem = 0, res = 0;
			long[] sum = new long[40];

			while (val1 != 0 || val2 != 0)
			{
				sum[i++] = (val1 % 10 + val2 % 10 + rem) % 2;
				rem = (val1 % 10 + val2 % 10 + rem) / 2;
				val1 = val1 / 10;
				val2 = val2 / 10;
			}
			if (rem != 0)
				sum[i++] = rem;

			i = i - 1;

			while (i >= 0)
				res = res * 10 + sum[i--];
			return res;
		}

		static int BinaryToDecimal(string binaryNumber)
		{
			int exponent = 0;
			int result = 0;
			for (var i = binaryNumber.Length - 1; i >= 0; i--)
			{
				if (binaryNumber[i] == '1')
				{
					result += Convert.ToInt32(Math.Pow(2, exponent));
				}
				exponent++;
			}

			return result;
		}
		static string Dop_Kod(string num, string s)
		{
			int minus = s.IndexOf('-');
			if (minus == 0)
			{
				string dopkod = "";
				dopkod = Convert.ToString(Sum(Convert.ToInt64(Obratniy_Kod(num, s)), 1));
				return dopkod;
			}
			else
				return num;
		}
		static string Obratniy_Kod(string num1, string n)
		{
			int minus = n.IndexOf('-');
			string obkod = "";
			if (minus == 0)
			{
				char[] a = num1.ToCharArray();
				int[] b = new int[a.Length];
				for (int i = 1; i < a.Length; i++)
				{
					if (a[i] == '0')
					{
						b[i] = 1;
					}
					if (a[i] == '1')
					{
						b[i] = 0;
					}
					obkod += Convert.ToString(b[i]);
				}
				return obkod;
			}
			else
			{
				return num1;
			}

		}

		static string Division(int n1, int n2, char[] a, char[] b)
		{
			string res;
			string ca, cb, n_iter, n_iter2;
			int len = n1 / n2;
			string slen = Convert.ToString(len, 2);
			
			char[] l = slen.ToCharArray();
			char[] result = new char[l.Length];
			ca = string.Join("", a);
			cb = string.Join("", b);
			string dop_b = Dop_Kod(cb, "-");
			if (a.Length >= b.Length)
			{
				char[] c = new char[b.Length];
				for (int j = 0; j <= b.Length - 1; j++)
				{
					c[j] = a[j];
				}
				ca = string.Join("", c);
				cb = string.Join("", b);
				string obr_cb = Dop_Kod(cb, "-");
				string res1 = Convert.ToString(Sum(Convert.ToInt64(ca), Convert.ToInt64(obr_cb)));
				n_iter = res1.Substring(1, res1.Length - 1);
				
				result[0] = '1';
				for (int i = 1; i <= l.Length-1; i++)
				{
					n_iter2 = n_iter + a[(b.Length-1) + i];
					
					int btd2 = BinaryToDecimal(n_iter2);
					MessageBox.Show(n_iter2);
					if (btd2 > n2)
					{
						result[i] = '1';
						string res2 = Convert.ToString(Sum(Convert.ToInt64(n_iter2), Convert.ToInt64(obr_cb)));
						//MessageBox.Show(res2);
					}
					else
					{
						result[i] = '0';
						n_iter2 = n_iter2 + a[(b.Length-1) + (i+1)];
						MessageBox.Show("fdjksb" + n_iter2);
					}
				}
				res = string.Join("", result);
			}
			else
			{
				char[] c = new char[a.Length];
				for (int j = 0; j <= a.Length - 1; j++)
				{
					c[j] = a[j];
				}
				res = string.Join("", c);
			}
			
			return res;
		}

		private void button2_Click(object sender, EventArgs e)
		{


            string ss = "";
            //Перевод в коды
            int minus = textBox1.Text.IndexOf('-');
            string text = textBox1.Text.Trim(new char[] { '-' });
            int k = Convert.ToInt32(text);
            string dig = Convert.ToString(k, 2);
            if (minus == 0)
            {
                for (int i = 1; i < 16 - (dig.Length - 1); i++)
                {
                    ss += "0";
                }
                label1.Text = "";
                label1.Text = dig;

            }
            else
            {
                for (int i = 1; i < 16 - (dig.Length - 1); i++)
                {
                    ss += "0";
                }
                label1.Text = "";
                label1.Text = dig;
            }
            string ss2 = "";
            int minus2 = textBox2.Text.IndexOf('-');
            string text2 = textBox2.Text.Trim(new char[] { '-' });
            int m = Convert.ToInt32(text2);
            string dig2 = Convert.ToString(m, 2);
            if (minus2 == 0)
            {

                for (int i = 1; i < 16 - (dig2.Length - 1); i++)
                {
                    ss2 += "0";
                }
                label2.Text = "";
                label2.Text = dig2;
            }
            else
            {
                for (int i = 1; i < 16 - (dig2.Length - 1); i++)
                {
                    ss2 += "0";
                }
                label2.Text = "";
                label2.Text = dig2;
            }

            int n1 = Convert.ToInt32(textBox1.Text);
			int n2 = Convert.ToInt32(textBox2.Text);
			string otv =Convert.ToString(division1(n1, n2));
			//string otv_res = Convert.ToString(Convert.ToInt32(otv), 2);
			
			int minus1 = textBox1.Text.IndexOf('-');
			minus2 = textBox2.Text.IndexOf('-');
			if ((minus1 == 0 && minus2 !=0) || (minus1 != 0 && minus2 == 0))
			{
				label3.Text = otv;
				string n_otv = otv.Remove(0, 1);
				string otv_res = Convert.ToString(Convert.ToInt32(n_otv), 2);
				label4.Text = "1. " + otv_res;
			}
			else if ((minus1 == 0 && minus2 == 0) || (minus1 != 0 && minus2 != 0))
			{
				label3.Text = otv;
				string otv_res = Convert.ToString(Convert.ToInt32(otv), 2);
				label4.Text = otv_res;
			}


           

        }

		int remainder = 0;
		int division1(int dividend, int divisor)
		{
			int quotient = 1;

			int neg = 1;
			if ((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0))
				neg = -1;

			// Convert to positive
			int tempdividend = (dividend < 0) ? -dividend : dividend;
			int tempdivisor = (divisor < 0) ? -divisor : divisor;

			if (tempdivisor == tempdividend)
			{
				remainder = 0;
				return 1 * neg;
			}
			else if (tempdividend < tempdivisor)
			{
				if (dividend < 0)
					remainder = tempdividend * neg;
				else
					remainder = tempdividend;
				return 0;
			}
			while (tempdivisor << 1 <= tempdividend)
{
				tempdivisor = tempdivisor << 1;
				quotient = quotient << 1;
			}

			// Call division recursively
			if (dividend < 0)
				quotient = quotient * neg + division1(-(tempdividend - tempdivisor), divisor);
			else
				quotient = quotient * neg + division1(tempdividend - tempdivisor, divisor);
			return quotient;
		}

        private void Button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label1.Text = " ";
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";

        }
    }
}
