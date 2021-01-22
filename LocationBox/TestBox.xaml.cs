using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;

namespace LocationBox
{
	/// <summary>
	/// Interaction logic for TestBox.xaml
	/// </summary>
	public partial class TestBox : UserControl
	{
		public TestBox()
		{
			InitializeComponent();
			
		}

        private string gCaption = string.Empty;
        private string gCaption1 = string.Empty;
        private string gCaption2 = string.Empty;
        public string Caption
        {
            set { gCaption = value; }
            get { return gCaption; }
        }

        public void SetCaption()
        {

            this.label1.Content = gCaption;
            //this.TextCaption.Text = gCaption;

        }

        public string Caption1
        {
            set { gCaption1 = value; }
            get { return gCaption1; }
        }

        public void SetCaption1()
        {

            this.label2.Content = gCaption1;
            //this.TextCaption.Text = gCaption;

        }
        public string Caption2
        {
            set { gCaption2 = value; }
            get { return gCaption2; }
        }

        public void SetCaption2()
        {

            this.label3.Content = gCaption2;
            //this.TextCaption.Text = gCaption;

        }

        #region Method
        public void BoxColorChange()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
        }

        public void BoxColorSearch()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
        }

        public void BoxColorDefault()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
        }

        public void setVisible(bool arg_visible)
        {
            //if (arg_visible)
            //    this.rectangle1.Visibility = System.Windows.Visibility.Visible;
            //else
            //    this.rectangle1.Visibility = System.Windows.Visibility.Hidden;

        }

        #endregion
	}
}
