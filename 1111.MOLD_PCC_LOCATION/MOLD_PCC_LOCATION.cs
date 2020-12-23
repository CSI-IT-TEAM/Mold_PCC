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

        private readonly Size _SizeCellHeader = new Size(80, 30);
        private readonly Size _SizeCellBody = new Size(80, 30);
        private readonly Size _SizeGrp = new Size(10,10);

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

            int locXStart = 10, locYStart = 10;
            int locX = locXStart, locY = locYStart;
            for (int iGrp = 0; iGrp < 4; iGrp ++)
            {
                CreateGrpHorizontal(ref locX, ref locY, loctionGrp[iGrp], loctionCell[iGrp]);
                locX += _SizeCellHeader.Width + 20;
                locY = locYStart;
            }

            locX = locXStart;

            CreateGrpHorizontal(ref locX, ref locY, "G", 24);

        }

        
        private void CreateGrpHorizontal(ref int argLocX, ref int argLocY, string argGrpName, int argQtyCell)
        {
            int locX = argLocX, locY = argLocY;
            int splitGrp = argQtyCell / 2;
            for (int i=1; i<= argQtyCell; i++)
            {               
                CreateCell(locX, locY, argGrpName + i.ToString("00"));
                //divice group 
                if (i == splitGrp)
                {
                    locX = argLocX;
                    locY += _SizeCellHeader.Height + _SizeCellBody.Height + 2;
                }
                else
                {
                    //Set location X next cell
                    locX += _SizeCellHeader.Width + 5;
                }               
            }
            argLocX = locX - 5;
            argLocY = locY;
        }

        private void CreateGrpVertical(ref int argLocX, ref int argLocY, string argGrpName, int argQtyCell)
        {
            int locX = argLocX, locY = argLocY;
            int splitGrp = argQtyCell / 2;
            for (int i = 1; i <= argQtyCell; i++)
            {
                CreateCell(locX, locY, argGrpName + i.ToString("00"));
                //divice group 
                if (i == splitGrp)
                {
                    locX = argLocX;
                    locY += _SizeCellHeader.Width + _SizeCellBody.Width + 5;
                }
                else
                {
                    //Set location X next cell
                    locX += _SizeCellHeader.Height + 2;
                }
            }
            argLocX = locX - 2;
            argLocY = locY;
        }

        private void CreateCell(int argLocX, int argLocY, string argLocName)
        {
            Point LocCell = new Point(argLocX, argLocY);
            Point LocQty = new Point(LocCell.X, LocCell.Y + _SizeCellHeader.Height);

            CreateCellHeader(LocCell, _SizeCellHeader, "cmd_Cel_" + argLocName, argLocName);
            CreateCellBody(LocQty, _SizeCellBody, "cmd_Qty_" + argLocName, "0/20");

        }

        private void CreateCellHeader(Point argLocation, Size argSize, string argName, string argText)
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
                cmd.Size = new Size(80, 30);
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

        private void CreateCellBody(Point argLocation, Size argSize, string argName, string argText)
        {
            Button cmd = new Button();
            try
            {
                cmd.FlatAppearance.BorderSize = 0;
                cmd.FlatStyle = FlatStyle.Flat;
                cmd.Font = new Font("Calibri", 10F, FontStyle.Bold);
                cmd.Location = argLocation;
                cmd.BackColor = Color.SkyBlue;
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

       

        private void CreateGrpHeader(Point argLocation, string argName, string argText)
        {
            Button cmd = new Button();
            try
            {
                cmd.FlatAppearance.BorderSize = 0;
                cmd.FlatStyle = FlatStyle.Flat;
                cmd.Font = new Font("Calibri", 10F, FontStyle.Bold);
                cmd.Location = argLocation;
                cmd.BackColor = Color.Yellow;
                cmd.ForeColor = Color.Black;
                cmd.Name = argName;
                cmd.Size = new Size(10, 10);
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
            throw new NotImplementedException();
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
