using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coursework_Phone
{
  public partial class Form1 : Form
  {

    private string _phoneNumber;
    private string PhoneNumber
    {
      get { return _phoneNumber; }
      set
      {
        _phoneNumber = value;

        string str = "";
        if (_phoneNumber.Length > 0) str = _phoneNumber[0] + " ";

        if (_phoneNumber.Length > 3) str += string.Format("({0}) ", _phoneNumber.Substring(1, 3));
        else if (_phoneNumber.Length > 1) str += string.Format("({0}) ", _phoneNumber.Substring(1));

        if (_phoneNumber.Length > 6) str += _phoneNumber.Substring(4, 3);
        else if (_phoneNumber.Length > 4)  str += _phoneNumber.Substring(4);

        if (_phoneNumber.Length > 8) str += "-" + _phoneNumber.Substring(7, 2);
        else if (_phoneNumber.Length > 7)  str += "-" +_phoneNumber.Substring(7);

        if (_phoneNumber.Length > 9) str += "-" + _phoneNumber.Substring(9);

        numberDialing.Text = str;
      }
    }

    public Form1()
    {
      InitializeComponent();
      _phoneNumber = numberDialing.Text;

      for (int i = 0; i < dialing.Controls.Count; i++)
        SetEllipseRegion(dialing.Controls[i]);
      for (int i = 0; i < calling.Controls.Count; i++)
        SetEllipseRegion(calling.Controls[i]);
    }
    private void SetEllipseRegion(Control control)
    {
      System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
      gPath.AddEllipse(0, 0, control.Width, control.Height);
      control.Region = new Region(gPath);
    }
    private void buttonDrop_Click(object sender, EventArgs e)
    {
      calling.Visible = false;
    }

    private void buttonCall_Click(object sender, EventArgs e)
    {
      status.Text = "Набор номера";
      numberCalling.Text = numberDialing.Text;
      calling.Visible = true;
      timer1.Start();
    }

    private byte ticks = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
      ticks++;
      if (ticks < 30)
      {
        string str = "Набор номера";
        sbyte dots = (sbyte)(ticks & 0b11);
        while (dots-- > 0) str += ".";
        status.Text = str;
      }
      else if (ticks < 40)
      {
        status.Text = "Не удалось дозвониться";
      }
      else
      {
        timer1.Stop();
        calling.Visible = false;
        ticks = 0;
      }
    }




    private void phoneTextAdd(char digit)
    {
      if (PhoneNumber.Length >= 11) return;
      PhoneNumber += digit;
    }

    private void button1_Click(object sender, EventArgs e) { phoneTextAdd('1'); }

    private void button2_Click(object sender, EventArgs e) { phoneTextAdd('2'); }

    private void button3_Click(object sender, EventArgs e) { phoneTextAdd('3'); }

    private void button4_Click(object sender, EventArgs e) { phoneTextAdd('4'); }

    private void button5_Click(object sender, EventArgs e) { phoneTextAdd('5'); }

    private void button6_Click(object sender, EventArgs e) { phoneTextAdd('6'); }

    private void button7_Click(object sender, EventArgs e) { phoneTextAdd('7'); }

    private void button8_Click(object sender, EventArgs e) { phoneTextAdd('8'); }

    private void button9_Click(object sender, EventArgs e) { phoneTextAdd('9'); }

    private void button0_Click(object sender, EventArgs e) { phoneTextAdd('0'); }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      if (numberDialing.Text.Length > 0)
        PhoneNumber = PhoneNumber.Remove(PhoneNumber.Length-1);
    }
  }
}
