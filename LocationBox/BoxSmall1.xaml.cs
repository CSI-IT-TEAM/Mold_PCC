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

namespace LocationBox
{
    /// <summary>
    /// Interaction logic for BoxSmall1.xaml
    /// </summary>
    public partial class BoxSmall1 : UserControl
    {
        public BoxSmall1()
        {
            InitializeComponent();
        }

        private string gCaption = string.Empty;
        private string gCaption1 = string.Empty;
        private int gSize = 84;
        System.Windows.Threading.DispatcherTimer _tmr_blink = new System.Windows.Threading.DispatcherTimer();
        private bool _b_Blink = true;

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

        public int lblSize
        {
            set { gSize = value; }
            get { return gSize; }
        }

        public void set_Lbl_Size()
        {

            this.label1.Width = gSize;
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


        #region Method

        #region Timer

        public void setBlink(bool arg_status)
        {
            if (arg_status)
            {
                _tmr_blink.Tick += new EventHandler(_tmr_blink_Tick);
                _tmr_blink.Interval = new TimeSpan(0, 0, 1);
                _tmr_blink.Start();

            }
            else
                _tmr_blink.Stop();
        }
        public void _tmr_blink_Tick(object sender, EventArgs e)
        {
            if (_b_Blink)
            {
                BoxColorDefault();
                BoxPolygonColor("default");
            }
            else
            {
                BoxColorSearch();
                BoxPolygonColor("search");
            }
            _b_Blink = !_b_Blink;
        }

        #endregion Timer

        public void BoxColorChange()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
        }

        public void BoxColorSearch()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
        }

        public void BoxColorDefault()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
        }

        public void BoxColorHead()
        {
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.Orange);
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Orange);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Orange);
        }

        public void BoxPolygonColor(string arg_status)
        {
            if (arg_status == "search")
                Polygon1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
            else if (arg_status == "change")
                Polygon1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
            else if (arg_status == "default")
                Polygon1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
            else if (arg_status == "head")
            {
                Polygon1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Orange);
            }
        }

        public void setRecTopSize()
        {

             RectTop.Margin = new Thickness(32, -94, -1, 9);

        }

        public void setRecRightSize()
        {
             RectRight.Margin = new Thickness(9, 30, -31, 0);
        }



        public void setVisible(bool arg_visible)
        {
            if (arg_visible)
                this.Polygon1.Visibility = System.Windows.Visibility.Visible;
            else
                this.Polygon1.Visibility = System.Windows.Visibility.Hidden;

        }

        public void setSizeBox(int w, int h)
        {
            GridBox.Width = w;
            GridBox.Height = h;

        }

        public void setFont(double argFontSizeTop, double argFontSizeFront)
        {
            label2.FontSize = argFontSizeTop;
            label1.FontSize = argFontSizeFront;
        }


        #endregion


    }
}
