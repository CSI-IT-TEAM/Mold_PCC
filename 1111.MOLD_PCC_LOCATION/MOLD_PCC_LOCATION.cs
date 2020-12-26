using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.IO;
using System.Collections;
//using JPlatform.Client.Controls;


namespace FORM
{
    public partial class MOLD_PCC_LOCATION : Form
    {
        public MOLD_PCC_LOCATION()
        {            
            InitializeComponent();
        }

        int _iReload = 0;

        enum ButtonProperties
        {
            Font,
            Size,
            Text,
            Name,
            Location,
            BackColor,
            ForeColor,
        }

        private readonly Size _SizeCellHeader = new Size(80, 25);
        private readonly Size _SizeCellBody = new Size(80, 22);

        private void SMT_QUALITY_COCKPIT_MAIN_Load(object sender, EventArgs e)
        {
            
        }

        private void SMT_SCADA_COCKPIT_MENU_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cmdBack.Visible = ComVar.Var._IsBack;
                _iReload = 0;
                CreateDesignLocation();

                tmrTime.Start();
            }
            else
            {
                tmrTime.Stop();
            }

        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _iReload++;
            if (_iReload >= 20)
            {
                _iReload = 0;
               
            }
        }

        #region Create Location Design

        private void CreateDesignLocation()
        {
            string[] loctionGrp = { "H", "I", "J", "K", "G", "F", "E", "D", "C", "B", "A" };
            int[] loctionCell = { 8, 8, 8, 8, 24, 32, 32, 30, 24, 24, 18 };

            int locXStart = 50, locYStart = 10;
            int locX = locXStart, locY = locYStart;
            int distanceGrpHorizontal = 100;
            int distanceGrpVertical = 110;
            for (int iGrp = 0; iGrp < 4; iGrp++)
            {
                CreateGrpHorizontal(ref locX, ref locY, loctionGrp[iGrp], loctionCell[iGrp]);
                locX +=  distanceGrpHorizontal;
                if (iGrp + 1 < 4) locY = locYStart;
            }

            locX = locXStart;
            locYStart = locY + _SizeCellHeader.Height + _SizeCellBody.Height + 20;

            for (int iGrp = 4; iGrp < loctionGrp.Length; iGrp++)
            {
                locY = locYStart;
                CreateGrpVertical(ref locX, ref locY, loctionGrp[iGrp], loctionCell[iGrp]);
                locX += _SizeCellHeader.Width + distanceGrpVertical;
            }

        }

        
        private void CreateGrpHorizontal(ref int argLocX, ref int argLocY, string argGrpName, int argQtyCell)
        {
            int locX = argLocX, locY = argLocY;
            int splitGrp = argQtyCell / 2;
            int distance2ColumnGrp = 1;
            int distance2RowGrp = 5;

            int heightGrpHeder = ((_SizeCellHeader.Height + _SizeCellBody.Height) * 2) + distance2RowGrp;
            int widthGrpHeder = 50;
            CreateGrpHeader(new Point(locX, locY), new Size(widthGrpHeder, heightGrpHeder), "cmd_Grp_" + argGrpName, argGrpName);           
            locX += widthGrpHeder;

            for (int i=1; i<= argQtyCell; i++)
            {               
                CreateCell(locX, locY, argGrpName + i.ToString("00"));
                //divice group 
                if (i == splitGrp)
                {
                    locX = argLocX + widthGrpHeder;
                    locY += _SizeCellHeader.Height + _SizeCellBody.Height + distance2RowGrp;
                }
                else
                {
                    //Set location X next cell
                    locX += _SizeCellHeader.Width + distance2ColumnGrp;
                }               
            }
            argLocX = locX - distance2ColumnGrp;
            argLocY = locY;
        }

        private void CreateGrpVertical(ref int argLocX, ref int argLocY, string argGrpName, int argQtyCell)
        {
            int locX = argLocX, locY = argLocY;
            int splitGrp = argQtyCell / 2;
            int distance2ColumnGrp = 5;
            int distance2RowGrp = 1;

            int withGrpHeder = (_SizeCellHeader.Width * 2) + distance2ColumnGrp;
            int heightGrpHeader = 50;
            CreateGrpHeader(new Point(locX, locY), new Size(withGrpHeder, heightGrpHeader), "cmd_Grp_" + argGrpName, argGrpName);
            locY += heightGrpHeader;

            for (int i = 1; i <= argQtyCell; i++)
            {
                CreateCell(locX, locY, argGrpName + i.ToString("00"));
                //divice group 
                if (i == splitGrp)
                {
                    locY = argLocY + heightGrpHeader;
                    locX += _SizeCellHeader.Width + distance2ColumnGrp;
                }
                else
                {
                    //Set location X next cell
                    locY += _SizeCellHeader.Height + _SizeCellBody.Height + distance2RowGrp;
                }
            }
            argLocY = locY - distance2RowGrp;
            argLocX = locX;
        }

        private void CreateCell(int argLocX, int argLocY, string argLocName)
        {
            Point LocCell = new Point(argLocX, argLocY);
            Point LocQty = new Point(LocCell.X, LocCell.Y + _SizeCellHeader.Height);

            CreateCellHeader(LocCell, "cmd_Che_" + argLocName, argLocName);
            CreateCellBody(LocQty, "cmd_Cbd_" + argLocName, "0/20");

        }

        private void CreateCellHeader(Point argLocation, string argName, string argText)
        {
            Button cmd = new Button();
            try
            {
                cmd.FlatAppearance.BorderSize = 0;
                cmd.FlatStyle = FlatStyle.Flat;
                cmd.Font = new Font("Calibri", 10F, FontStyle.Bold);
                cmd.Location = argLocation;
                cmd.BackColor = Color.Black;
                cmd.ForeColor = Color.White;
                cmd.Name = argName;
                cmd.Size = _SizeCellHeader;
                cmd.Text = argText;
                cmd.UseVisualStyleBackColor = true;
                cmd.Click += new EventHandler(Button_Create_Click);
                pnLocation.Controls.Add(cmd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void CreateCellBody(Point argLocation, string argName, string argText)
        {
            Button cmd = new Button();
            try
            {
                cmd.FlatAppearance.BorderSize = 0;
                cmd.FlatStyle = FlatStyle.Flat;
                cmd.Font = new Font("Calibri", 10F);
                cmd.Location = argLocation;
                cmd.BackColor = Color.SkyBlue;
                cmd.ForeColor = Color.Black;
                cmd.Name = argName;
                cmd.Size = _SizeCellBody;
                cmd.Text = argText;
                cmd.TextAlign = ContentAlignment.TopCenter;
                cmd.UseVisualStyleBackColor = true;
                cmd.Click += new EventHandler(Button_Create_Click);
                pnLocation.Controls.Add(cmd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void CreateGrpHeader(Point argLocation, Size argSize, string argName, string argText)
        {
            Button cmd = new Button();
            try
            {
                cmd.FlatAppearance.BorderSize = 0;
                cmd.FlatStyle = FlatStyle.Flat;
                cmd.Font = new Font("Calibri", 25F, FontStyle.Bold);
                cmd.Location = argLocation;
                cmd.BackColor = Color.Yellow;
                cmd.ForeColor = Color.Black;
                cmd.Name = argName;
                cmd.Size = argSize;
                cmd.Text = argText;
                cmd.UseVisualStyleBackColor = true;
                cmd.Click += new EventHandler(Button_Create_Click);
                pnLocation.Controls.Add(cmd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            MessageBox.Show(ctr.Name);
        }



        #endregion


        #region DB
        private DataTable Data_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "SEPHIROTH.PKG_SMT_QUALITY_COCKPIT_02.MAIN_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }


        #endregion DB

        #region Event


        #endregion

       

    }
}
