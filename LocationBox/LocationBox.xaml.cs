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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Drawing;

using System.Runtime.InteropServices;





namespace LocationBox
{


    /// <summary>
    /// Box.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Box : UserControl
    {
        #region Declare
        public enum DefaultColor { Gray = 0, Yellow = 1, Red = 2, Blue = 3, Black = 4 } //Default Color 
        public enum HighlightColor { Gray = 0, Yellow = 1, Red = 2, Blue = 3, Black = 4 } //Hightlight Animation Color 

        private DefaultColor gDefaultColor = DefaultColor.Gray;
        private HighlightColor gHighlightColor;

        private int iAniDuration = 1; //Second

        private Dictionary<string, bool> continued = new Dictionary<string, bool>();        
        private int currentName;

        private int iAnimationSecond = 3;


        /// <summary>
        /// Hightlight Color Struct
        /// </summary>
        private struct sBoxColor
        {
            public Color Front;
            public Color Right;
            public Color Top;
        }

        sBoxColor defaultColor = new sBoxColor();
        sBoxColor highlightColor = new sBoxColor();

        private string gLine = string.Empty;
        private string gMline = string.Empty;
		private string gFloor = string.Empty;
        private string gCaption = string.Empty;
        private string gCaption1 = string.Empty;
        private string gCaption2 = string.Empty;
		private string gCaptionWith = string.Empty;

        #endregion

        #region Property
        /// <summary>
        /// Line
        /// </summary>
        public string Line
        {
            set { gLine = value; }
            get { return gLine; }
        }

        /// <summary>
        /// Secondry Line 
        /// </summary>
        public string Mline
        {
            set { gMline = value; }
            get { return gLine; }
        }

        /// <summary>
        /// Floor
        /// </summary>
        public string Floor
        {
            set { gFloor = value; }
            get { return gFloor; }
        }

        /// <summary>
        /// Defalut Color Set
        /// </summary>
        
        public DefaultColor BoxDefaultColor
        {
            set 
            { 
                gDefaultColor = value;
                SetDefaultColor(gDefaultColor);
            }
        }

        /// <summary>
        /// Highlight Color set 
        /// </summary>
        public HighlightColor BoxHighlightColor
        {
            set 
            { 
                gHighlightColor = value;
                SetHightlightColor(gHighlightColor); 

            }
        }

        public void setVisible(bool arg_visible)
        {
            if (arg_visible)
                this.rectangle1.Visibility = System.Windows.Visibility.Visible;
            else
                this.rectangle1.Visibility = System.Windows.Visibility.Hidden;

        }


        #endregion

        #region Creation
        public Box()
        {
            InitializeComponent();
        }
        #endregion

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
            RectFront.Fill = new SolidColorBrush(System.Windows.Media.Colors.LightGray );
            RectTop.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
            RectRight.Fill = new SolidColorBrush(System.Windows.Media.Colors.Salmon);
        }


        private void SetDefaultColor(DefaultColor color)
        {
            switch (color)
            {
                case DefaultColor.Gray:
                    defaultColor.Front = Brushes.LightGray.Color;
                    defaultColor.Top = Brushes.DarkGray.Color;
                    defaultColor.Right = Brushes.DarkGray.Color;
                    break;
                case DefaultColor.Yellow:
                    defaultColor.Front = Brushes.LightYellow.Color;
                    defaultColor.Top = Brushes.LightGoldenrodYellow.Color;
                    defaultColor.Right = Brushes.LightGoldenrodYellow.Color;

                    break;
                case DefaultColor.Red:
                    defaultColor.Front = Brushes.Red.Color;
                    defaultColor.Top = Brushes.DarkRed.Color;
                    defaultColor.Right = Brushes.DarkRed.Color;
                    break;
                case DefaultColor.Blue:
                    defaultColor.Front = Brushes.LightBlue.Color;
                    defaultColor.Top = Brushes.CadetBlue.Color;
                    defaultColor.Right = Brushes.CadetBlue.Color;
                    break;
                case DefaultColor.Black:
                    defaultColor.Front = Brushes.DarkGray.Color;
                    defaultColor.Top = Brushes.Black.Color;
                    defaultColor.Right = Brushes.Black.Color;
                    break;
            }

           // SetBoxColor(defaultColor);
            
        }

        private void SetHightlightColor(HighlightColor color)
        {
            switch (color)
            {
                case HighlightColor.Gray:
                    highlightColor.Front = Brushes.LightGray.Color;
                    highlightColor.Top = Brushes.DarkGray.Color;
                    highlightColor.Right = Brushes.DarkGray.Color;
                    break;
                case HighlightColor.Yellow:
                    highlightColor.Front = Brushes.LightYellow.Color;
                    highlightColor.Top = Brushes.LightGoldenrodYellow.Color;
                    highlightColor.Right = Brushes.LightGoldenrodYellow.Color;

                    break;
                case HighlightColor.Red:
                    highlightColor.Front = Brushes.Red.Color;
                    highlightColor.Top = Brushes.DarkRed.Color;
                    highlightColor.Right = Brushes.DarkRed.Color;
                    break;
                case HighlightColor.Blue:
                    highlightColor.Front = Brushes.LightBlue.Color;
                    highlightColor.Top = Brushes.CadetBlue.Color;
                    highlightColor.Right = Brushes.CadetBlue.Color;
                    break;
                case HighlightColor.Black:
                    highlightColor.Front = Brushes.DarkGray.Color;
                    highlightColor.Top = Brushes.Black.Color;
                    highlightColor.Right = Brushes.Black.Color;
                    break;
            }
        }


        /// <summary>
        /// Hightlight Animation
        /// </summary>
        public void HightLight()
        {
            //iAnimationSecond = animationSecond;

            Storyboard boxStoryBoard = new Storyboard();
            string nameTemp = DateTime.Now.ToFileTime().ToString();

            SolidColorBrush FrontsolidColorBrush = new SolidColorBrush(defaultColor.Front);
            //NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("FrontSolidName" + nameTemp, FrontsolidColorBrush);
            RectFront.Fill = FrontsolidColorBrush;

            SolidColorBrush TopsolidColorBrush = new SolidColorBrush(defaultColor.Top);
            //NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("TopSolidName" + nameTemp, TopsolidColorBrush);
            RectTop.Fill = TopsolidColorBrush;

            SolidColorBrush RightsolidColorBrush = new SolidColorBrush(defaultColor.Right);
            //NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("RightSolidName" + nameTemp, RightsolidColorBrush);
            RectRight.Fill = RightsolidColorBrush;
           

            ColorAnimation frontAni = new ColorAnimation();
            frontAni.From = defaultColor.Front;
            frontAni.To = highlightColor.Front;
            frontAni.Duration = new Duration(TimeSpan.FromSeconds(iAniDuration));
            frontAni.AutoReverse = true;
            //Storyboard.SetTargetName(frontAni, "FrontSolidColorBrush");
            Storyboard.SetTargetName(frontAni, "FrontSolidName" + nameTemp);
            Storyboard.SetTargetProperty(frontAni, new PropertyPath(SolidColorBrush.ColorProperty));

            ColorAnimation topAni = new ColorAnimation();
            topAni.From = defaultColor.Top;
            topAni.To = highlightColor.Top;
            topAni.Duration = new Duration(TimeSpan.FromSeconds(iAniDuration));
            topAni.AutoReverse = true;
            Storyboard.SetTargetName(topAni, "TopSolidName" + nameTemp);
            Storyboard.SetTargetProperty(topAni, new PropertyPath(SolidColorBrush.ColorProperty));

            ColorAnimation rightAni = new ColorAnimation();
            rightAni.From = defaultColor.Right;
            rightAni.To = highlightColor.Right;
            rightAni.Duration = new Duration(TimeSpan.FromSeconds(iAniDuration));
            rightAni.AutoReverse = true;
            Storyboard.SetTargetName(rightAni, "RightSolidName" + nameTemp);
            Storyboard.SetTargetProperty(rightAni, new PropertyPath(SolidColorBrush.ColorProperty));
            
            boxStoryBoard.Children.Add(frontAni);
            boxStoryBoard.Children.Add(topAni);
            boxStoryBoard.Children.Add(rightAni);

            //RectFront.MouseUp += delegate(object sender, MouseEventArgs e)
            //RectFront.MouseUp += delegate(object sender, MouseButtonEventArgs e)
            //{
            //boxStoryBoard.RepeatBehavior = RepeatBehavior.Forever;
            boxStoryBoard.Begin(this);
            


            //};
            
        }

        private void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            Clock clock = (Clock)sender;
            Storyboard sb = (Storyboard)clock.Timeline;
            if (!continued[sb.Name])
            {
                TimeSpan? time = clock.CurrentTime;               

                if (time != null && time >= TimeSpan.FromSeconds(iAnimationSecond))
                {
                    
                    Storyboard sb2 = sb.Clone();
                    sb2.CurrentTimeInvalidated += new EventHandler(Storyboard_CurrentTimeInvalidated);
                    sb2.Name = "boxStoryBoard" + currentName.ToString();
                    currentName++;
                    continued.Add(sb2.Name, false);
                    sb2.Begin(this);
                    continued[sb.Name] = true;
                }
            }
        }


        public void StopHighlight()
        {
            
            //boxStoryBoard.Stop();
        }
        #endregion


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

        

        #region Event
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }
        #endregion

        private void Box_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

		private void LocBox_Loaded(object sender, RoutedEventArgs e)
		{

		}






        /*
        public Bitmap GetSnapShot()
        {
            using (Image image = new Bitmap(canvasBounds.Width, canvasBounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point
                    (canvasBounds.Left, canvasBounds.Top), Point.Empty, canvasBounds.Size);
                }
                return new Bitmap(SetBorder(image, Color.Black, 1));
            }
        }*/






    }
}
