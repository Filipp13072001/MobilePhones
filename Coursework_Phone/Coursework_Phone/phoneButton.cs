using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Phone
{
  public partial class phoneButton : UserControl
  {
    public phoneButton()
    {
      InitializeComponent();
      System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
      gPath.AddEllipse(0, 0, this.Width, this.Height);
      this.Region = new Region(gPath);
    }

    private void phoneButton_Resize(object sender, EventArgs e)
    {
      System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
      gPath.AddEllipse(0, 0, this.Width, this.Height);
      this.Region = new Region(gPath);
    }
  }
}
