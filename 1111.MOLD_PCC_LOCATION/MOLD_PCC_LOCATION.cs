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
using System.Windows.Forms.Integration;
using System.Windows.Input;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts.Native;
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

        enum BoxStatus
        {
            Search,
            Empty,
            Click,
            Default,
        }

        //private readonly Size _SizeCellHeader = new Size(80, 25);
        //private readonly Size _SizeCellBody = new Size(80, 22);
        //private Dictionary<string, int> _DtnLocation = new Dictionary<string, int>();
        DataTable _dt_Shelf = null;
        DataTable _dt_Combo = null;
        int rows_dt_shelf;
        int index = 1;
        Dictionary<string, ElementHost> _DtnBox = new Dictionary<string, ElementHost>();
        List<string> _lstSearch = new List<string>();
        private void SMT_QUALITY_COCKPIT_MAIN_Load(object sender, EventArgs e)
        {
           // test();
            
            InitLocation();
            LoadBoxQty();
            // LoadData();
        }

        private void SMT_SCADA_COCKPIT_MENU_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cmdBack.Visible = ComVar.Var._IsBack;
                _iReload = 20;
                
                // CreateDesignLocation();

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
                LoadData();
            }
        }

        #region Location Box
        #region Create Loction Box
        private async void InitLocation()
        {
            try
            {
                pnLocation.Visible = false;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                _dt_Shelf = await SELECT_MOLD_LOCATED_MASTER();

                rows_dt_shelf = _dt_Shelf.Rows.Count;
                //int x1 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_x"]);
                //int y1 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_y"]);

                //int x2 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_x"]);
                //int y2 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_y"]);

                int y0 = 100;
                int x, y, w_element, h_element, w_box, h_box, plus_x;
                x = Convert.ToInt32(_dt_Shelf.Rows[0]["col_x"]);
                y = Convert.ToInt32(_dt_Shelf.Rows[0]["col_y"]);
                plus_x = Convert.ToInt32(_dt_Shelf.Rows[0]["plus_x"]);
                bool b_background = false;

                //CreateBox(x, y, _dt_Shelf.Rows[0]["shelf"].ToString(), "", _dt_Shelf.Rows[0]["cell"].ToString(), w, h, false);

                for (int i = 0; i < rows_dt_shelf; i++)
                {
                    //if (i == 5)
                    //    break;
                    string shelf = _dt_Shelf.Rows[i]["shelf"].ToString();
                    switch (_dt_Shelf.Rows[i]["status"].ToString())
                    {
                        case "":
                            x += Convert.ToInt32(_dt_Shelf.Rows[i]["plus_x"]); ;
                            y = y0;
                            b_background = true;
                            break;
                        case "NEW_LINE":
                            x = Convert.ToInt32(_dt_Shelf.Rows[i]["col_x"]);
                            y = Convert.ToInt32(_dt_Shelf.Rows[i]["col_y"]);
                            y0 = y;
                            if (shelf == "O37") b_background = true;
                            else 
                                b_background = false;
                            break;
                            //case "":
                            //    x += 15;;
                            //    y -= 32;
                            //    b_background = false;                           
                            //    break;
                            //case "NEW_LINE":
                            //    x = Convert.ToInt32(_dt_Shelf.Rows[i]["col_x"]);
                            //    y = Convert.ToInt32(_dt_Shelf.Rows[i]["col_y"]);
                            //    y0 = y;
                            //    b_background = false;
                            //    break;
                    }
                    w_element = Convert.ToInt32(_dt_Shelf.Rows[i]["element_host_W"]);
                    h_element = Convert.ToInt32(_dt_Shelf.Rows[i]["element_host_H"]);
                    w_box = Convert.ToInt32(_dt_Shelf.Rows[i]["box_W"]);
                    h_box = Convert.ToInt32(_dt_Shelf.Rows[i]["box_H"]);
                    string head = _dt_Shelf.Rows[i]["HEAD"].ToString();
                    
                    

                    CreateBox(x, y, head, w_element, h_element
                            , w_box, h_box, b_background, _dt_Shelf.Rows[i]["shelf"].ToString(), _dt_Shelf.Rows[i]["qty"].ToString(), Convert.ToInt32(_dt_Shelf.Rows[i]["lbl_width"]));
                    //CreateBox(x, y, _dt_Shelf.Rows[i]["NAME"].ToString(), "", _dt_Shelf.Rows[i]["cell"].ToString(), w_element, h_element
                    //         , w_box, h_box, b_background,_dt_Shelf.Rows[i]["shelf"].ToString()+ "\n" + _dt_Shelf.Rows[i]["qty"].ToString(), Convert.ToInt32(_dt_Shelf.Rows[i]["lbl_width"]));
                }

               // _DtnLocation = new Dictionary<string, int>();
                //for (int i = 0; i < pn_loc_wh.Controls.Count; i++)
                //{
                //    _Dic_Location.Add(pn_loc_wh.Controls[i].Name, i);
                //}

                //for (int i = 0; i < gp1.Controls.Count; i++)
                //{
                //    _Dic_Location.Add(gp1.Controls[i].Name, i);
                //}

                //for (int i = 0; i < gp2.Controls.Count; i++)
                //{
                //    _Dic_Location.Add(gp2.Controls[i].Name, i);
                //}

                //for (int i = 0; i < gp3.Controls.Count; i++)
                //{
                //    _Dic_Location.Add(gp3.Controls[i].Name, i);
                //}

                //for (int i = 0; i < pn_Wh_Detail.Controls.Count; i++)
                //{
                //    _Dic_Location.Add(pn_Wh_Detail.Controls[i].Name, i);
                //}


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                pnLocation.Visible = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void CreateBox(int x, int y, string head, int w_element, int h_element, int w_box, int h_box, bool bg_clolor, string text_front, string arg_qty, int arg_lbl_width)
        {
            //this.BeginInvoke((Action)(() =>
            //{

            ElementHost Element = new System.Windows.Forms.Integration.ElementHost();
            LocationBox.BoxSmall1 box = new LocationBox.BoxSmall1();

            //if (shelf == "B12")
            //{
            //    w_element = 130;
            //    h_element = 200;
            //    h_box = 200;
            //    w_box = 144;
            //    box.setRecRightSize();
            //    box.setRecTopSize();
            //}

            box.setSizeBox(w_box, h_box);

            if (text_front == "H01" || text_front == "I01" || text_front == "J01" || text_front == "K01")
            {
                box.BoxPolygonColor("head");
            }
            else
            {
                box.setVisible(bg_clolor);
            }
            //box.Caption = arg_qty.Substring(0, 1);
            if (arg_qty == "O")
            { }
            box.Caption = arg_qty == "O" ? "Other" : arg_qty == "L" ? "Long Thanh" : arg_qty.Replace("_", "\n");
            box.SetCaption();
            // box.Caption1 = shelf.Substring(1, 2);
            box.Caption1 = "";
            //if (arg_qty == "0")
            //{
            //    box.BoxColorEmpty();
            //}
            //if (head == "Y")
            //{
            //    box.Caption1 = "";
            //}
            //else
            //{
            //    box.Caption1 = text_front;
            //}
            box.SetCaption1();
            box.TabIndex = index;
            box.lblSize = arg_lbl_width;
            box.set_Lbl_Size();
            box.Name = text_front;
            box.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(BoxHead_MouseLeftButtonUp);

            Element.Name = text_front;
            Element.Location = new Point(x, y);
            Element.Size = new Size(w_element, h_element);
            Element.TabIndex = index;

            if (head == "Y")
            {
                box.BoxColorHead();
                box.setFont(30, 30);

            }


            //  if (bg_clolor) Element.BackColor = Color.SkyBlue;

            Element.Child = box;
            //  if (bf== true) 
            //     Element.SendToBack();
            // Element.BringToFront();
            // Element.BackColor = Color.White;

            //perform on the UI thread
            //     this.Controls.Add(Element);

            pnLocation.Controls.Add(Element);

            _DtnBox.Add(Element.Name, Element);

            //if (box.Name.Substring(0, 1) == "A")
            //    gp1.Controls.Add(Element);
            //else if (box.Name.Substring(0, 1) == "B")
            //    gp2.Controls.Add(Element);
            //else if (box.Name.Substring(0, 1) == "C")
            //    gp3.Controls.Add(Element);
            //else
            //    pn_Wh_Detail.Controls.Add(Element);
            Element.BringToFront();
            //this.Controls.Add(Element);
            //Element.BringToFront();
            index++;
            //}));
        }

        #endregion Create Loction Box	

        #region Click Box
        private void BoxHead_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)sender;

                if (box.Name != "L" && box.Name.Length == 1) return;

                MOLD_PCC_POP_DETAIL popup = new MOLD_PCC_POP_DETAIL
                {
                    _location = box.Name
                };
                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion Click Box

        private async void LoadBoxQty()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DataTable dt = await SELECT_MOLD_LOCATED_CNT();

                if (dt == null) return;

                object totalMold = dt.Compute("SUM(QTY)","");

                int.TryParse(totalMold.ToString(), out int moldQty);

                lbl_Total.Text = "Total Mold\n" + ((int)moldQty).ToString("###,###");


                foreach (DataRow row in dt.Rows)
                {
                    string located = row["located"].ToString();
                    string qty = row["qty"].ToString();
                    string space = " ";//qty.Length == 4 ? " " : "  ";

                    if (_DtnBox.ContainsKey(located))
                    {
                        LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)_DtnBox[located].Child;
                        box.Caption = located + "\n" + space + qty;
                        box.SetCaption();
                        if (qty == "0")
                        {
                            box.BoxColorEmpty();
                           // box.setBlink(false);
                        }
                        else if (!_lstSearch.Contains(located))
                        {
                            box.BoxColorDefault();
                          //  box.setBlink(false);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion Location Box

        #region Create Location Design

        //private void CreateDesignLocation()
        //{
        //    string[] loctionGrp = { "H", "I", "J", "K", "G", "F", "E", "D", "C", "B", "A" };
        //    int[] loctionCell = { 8, 8, 8, 8, 24, 32, 32, 30, 24, 24, 18 };

        //    int locXStart = 50, locYStart = 10;
        //    int locX = locXStart, locY = locYStart;
        //    int distanceGrpHorizontal = 100;
        //    int distanceGrpVertical = 110;
        //    for (int iGrp = 0; iGrp < 4; iGrp++)
        //    {
        //        CreateGrpHorizontal(ref locX, ref locY, loctionGrp[iGrp], loctionCell[iGrp]);
        //        locX +=  distanceGrpHorizontal;
        //        if (iGrp + 1 < 4) locY = locYStart;
        //    }

        //    locX = locXStart;
        //    locYStart = locY + _SizeCellHeader.Height + _SizeCellBody.Height + 20;

        //    for (int iGrp = 4; iGrp < loctionGrp.Length; iGrp++)
        //    {
        //        locY = locYStart;
        //        CreateGrpVertical(ref locX, ref locY, loctionGrp[iGrp], loctionCell[iGrp]);
        //        locX += _SizeCellHeader.Width + distanceGrpVertical;
        //    }

        //}


        //private void CreateGrpHorizontal(ref int argLocX, ref int argLocY, string argGrpName, int argQtyCell)
        //{
        //    int locX = argLocX, locY = argLocY;
        //    int splitGrp = argQtyCell / 2;
        //    int distance2ColumnGrp = 1;
        //    int distance2RowGrp = 5;

        //    int heightGrpHeder = ((_SizeCellHeader.Height + _SizeCellBody.Height) * 2) + distance2RowGrp;
        //    int widthGrpHeder = 50;
        //    CreateGrpHeader(new Point(locX, locY), new Size(widthGrpHeder, heightGrpHeder), "cmd_Grp_" + argGrpName, argGrpName);           
        //    locX += widthGrpHeder;

        //    for (int i=1; i<= argQtyCell; i++)
        //    {               
        //        CreateCell(locX, locY, argGrpName + i.ToString("00"));
        //        //divice group 
        //        if (i == splitGrp)
        //        {
        //            locX = argLocX + widthGrpHeder;
        //            locY += _SizeCellHeader.Height + _SizeCellBody.Height + distance2RowGrp;
        //        }
        //        else
        //        {
        //            //Set location X next cell
        //            locX += _SizeCellHeader.Width + distance2ColumnGrp;
        //        }               
        //    }
        //    argLocX = locX - distance2ColumnGrp;
        //    argLocY = locY;
        //}

        //private void CreateGrpVertical(ref int argLocX, ref int argLocY, string argGrpName, int argQtyCell)
        //{
        //    int locX = argLocX, locY = argLocY;
        //    int splitGrp = argQtyCell / 2;
        //    int distance2ColumnGrp = 5;
        //    int distance2RowGrp = 1;

        //    int withGrpHeder = (_SizeCellHeader.Width * 2) + distance2ColumnGrp;
        //    int heightGrpHeader = 50;
        //    CreateGrpHeader(new Point(locX, locY), new Size(withGrpHeder, heightGrpHeader), "cmd_Grp_" + argGrpName, argGrpName);
        //    locY += heightGrpHeader;

        //    for (int i = 1; i <= argQtyCell; i++)
        //    {
        //        CreateCell(locX, locY, argGrpName + i.ToString("00"));
        //        //divice group 
        //        if (i == splitGrp)
        //        {
        //            locY = argLocY + heightGrpHeader;
        //            locX += _SizeCellHeader.Width + distance2ColumnGrp;
        //        }
        //        else
        //        {
        //            //Set location X next cell
        //            locY += _SizeCellHeader.Height + _SizeCellBody.Height + distance2RowGrp;
        //        }
        //    }
        //    argLocY = locY - distance2RowGrp;
        //    argLocX = locX;
        //}

        //private void CreateCell(int argLocX, int argLocY, string argLocName)
        //{
        //    Point LocCell = new Point(argLocX, argLocY);
        //    Point LocQty = new Point(LocCell.X, LocCell.Y + _SizeCellHeader.Height);

        //    CreateCellHeader(LocCell, "cmd_Che_" + argLocName, argLocName);
        //    CreateCellBody(LocQty, "cmd_Cbd_" + argLocName, "0/20");

        //}

        //private void CreateCellHeader(Point argLocation, string argName, string argText)
        //{
        //    Button cmd = new Button();
        //    try
        //    {
        //        cmd.FlatAppearance.BorderSize = 0;
        //        cmd.FlatStyle = FlatStyle.Flat;
        //        cmd.Font = new Font("Calibri", 10F, FontStyle.Bold);
        //        cmd.Location = argLocation;
        //        cmd.BackColor = Color.Black;
        //        cmd.ForeColor = Color.White;
        //        cmd.Name = argName;
        //        cmd.Size = _SizeCellHeader;
        //        cmd.Text = argText;
        //        cmd.UseVisualStyleBackColor = true;
        //        cmd.Click += new EventHandler(Button_Create_Click);
        //        pnLocation.Controls.Add(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //}

        //private void CreateCellBody(Point argLocation, string argName, string argText)
        //{
        //    Button cmd = new Button();
        //    try
        //    {
        //        cmd.FlatAppearance.BorderSize = 0;
        //        cmd.FlatStyle = FlatStyle.Flat;
        //        cmd.Font = new Font("Calibri", 10F);
        //        cmd.Location = argLocation;
        //        cmd.BackColor = Color.SkyBlue;
        //        cmd.ForeColor = Color.Black;
        //        cmd.Name = argName;
        //        cmd.Size = _SizeCellBody;
        //        cmd.Text = argText;
        //        cmd.TextAlign = ContentAlignment.TopCenter;
        //        cmd.UseVisualStyleBackColor = true;
        //        cmd.Click += new EventHandler(Button_Create_Click);
        //        pnLocation.Controls.Add(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //}

        //private void CreateGrpHeader(Point argLocation, Size argSize, string argName, string argText)
        //{
        //    Button cmd = new Button();
        //    try
        //    {
        //        cmd.FlatAppearance.BorderSize = 0;
        //        cmd.FlatStyle = FlatStyle.Flat;
        //        cmd.Font = new Font("Calibri", 25F, FontStyle.Bold);
        //        cmd.Location = argLocation;
        //        cmd.BackColor = Color.Yellow;
        //        cmd.ForeColor = Color.Black;
        //        cmd.Name = argName;
        //        cmd.Size = argSize;
        //        cmd.Text = argText;
        //        cmd.UseVisualStyleBackColor = true;
        //        cmd.Click += new EventHandler(Button_Create_Click);
        //        pnLocation.Controls.Add(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //}

        //private void Button_Create_Click(object sender, EventArgs e)
        //{
        //    Control ctr = (Control)sender;
        //    MessageBox.Show(ctr.Name);
        //}

        #endregion


        private async void LoadData()
        {
            try
            {
                LoadBoxQty();

                _dt_Combo = await SEL_MOLD_LOCTED_SEARCH();
                SetCombobox(GetDataModel(), cbo_Model);
                SetCombobox(GetDataMoldCode(cbo_Model.Text), cbo_MoldCd);
                SetCombobox(GetDataMoldSize(cbo_Model.Text, cbo_MoldCd.Text), cbo_Size);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

       

        #region Combobox
        private void cbo_Model_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SetCombobox(GetDataMoldCode(cbo_Model.Text), cbo_MoldCd);
            SetCombobox(GetDataMoldSize(cbo_Model.Text, cbo_MoldCd.Text), cbo_Size);
        }

        private void cbo_MoldCd_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SetCombobox(GetDataMoldSize(cbo_Model.Text, cbo_MoldCd.Text), cbo_Size);
        }

        private bool CompareDatatable(DataTable arg_Dt1, DataTable arg_Dt2)
        {
            // Fast check for row count equality.
            if (arg_Dt1.Rows.Count != arg_Dt2.Rows.Count)
            {
                return true;
            }

            var differences = arg_Dt1.AsEnumerable().Except(arg_Dt2.AsEnumerable(), DataRowComparer.Default);

            return differences.Any();// ? differences.CopyToDataTable() : new DataTable();
        }

        private DataTable GetDataModel()
        {
            try
            {
                DataTable dt = _dt_Combo.DefaultView.ToTable(true, "MODEL_NM").Copy();
                DataTable dtRtn = dt.Select("", "MODEL_NM").CopyToDataTable();
                DataRow dr = dtRtn.NewRow();
                dr[0] = "ALL";
                dtRtn.Rows.InsertAt(dr, 0);

                return dtRtn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            
        }

        private DataTable GetDataMoldCode(string arg_ModelNm = "")
        {
            try
            {
                string condition = arg_ModelNm == "ALL" ? "" : arg_ModelNm;
                DataTable dt = _dt_Combo.Select($"MODEL_NM like '{condition}%'").CopyToDataTable();
                DataTable dtRtn = dt.DefaultView.ToTable(true, "MOLD_CD").Select("", "MOLD_CD").CopyToDataTable();
                DataRow dr = dtRtn.NewRow();
                dr[0] = "ALL";
                dtRtn.Rows.InsertAt(dr, 0);
                return dtRtn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }

        }

        private DataTable GetDataMoldSize(string arg_ModelNm = "", string arg_MoldCode = "")
        {
            try
            {
                string condition1 = arg_ModelNm == "ALL" ? "" : arg_ModelNm;
                string condition2 = arg_MoldCode == "ALL" ? "" : arg_MoldCode;
                DataTable dt = _dt_Combo.Select($"MODEL_NM like '{condition1}%' and MOLD_CD like '{condition2}%'", "SIZE_NUM").CopyToDataTable();
                DataTable dtRtn = dt.DefaultView.ToTable(true, "USE_SIZE", "SIZE_NUM").Select("", "SIZE_NUM").CopyToDataTable();
                DataRow dr = dtRtn.NewRow();
                dr[0] = "ALL";
                dtRtn.Rows.InsertAt(dr, 0);
                return dtRtn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
                
            }
            
        }

        private void SetCombobox(DataTable arg_Dt, LookUpEdit arg_Cbo)
        {
            if (arg_Cbo.IsPopupOpen) return;
            bool dif = true;
            if (arg_Cbo.Properties.DataSource != null)
            {
                dif = CompareDatatable((DataTable)arg_Cbo.Properties.DataSource, arg_Dt);
            }
            if (!dif) return;           
            if (arg_Dt == null)
            {
                arg_Cbo.Properties.DataSource = arg_Dt;
                return;
            }

            arg_Cbo.Properties.Columns.Clear();
            arg_Cbo.Properties.DataSource = arg_Dt;
            arg_Cbo.Properties.ValueMember = arg_Dt.Columns[0].ColumnName;
            arg_Cbo.Properties.DisplayMember = arg_Dt.Columns[0].ColumnName;
            arg_Cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(arg_Dt.Columns[0].ColumnName));
            //cbo_Model.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(arg_Dt.Columns[1].ColumnName));
            //cbo_Model.Properties.Columns[arg_Dt.Columns[0].ColumnName].Visible = false;
            arg_Cbo.ItemIndex = 0;
        }
        #endregion

        #region DB
        private async Task<DataTable> SELECT_MOLD_LOCATED_MASTER()
        {
            return await Task.Run(() => {
                try
                {
                    COM.OraDB MyOraDB = new COM.OraDB();
                    DataSet ds_ret;
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;

                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_LOCATED_MASTER";

                    MyOraDB.ReDim_Parameter(2);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                    MyOraDB.Parameter_Name[1] = "ARG_WH_CD";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;

                    MyOraDB.Parameter_Values[0] = "";
                    MyOraDB.Parameter_Values[1] = "10";

                    MyOraDB.Add_Select_Parameter(true);
                    ds_ret = MyOraDB.Exe_Select_Procedure();

                    if (ds_ret == null) return null;
                    return ds_ret.Tables[process_name];
                }
                catch
                {
                    return null;
                }
            });


        }
        private async Task<DataTable> SELECT_MOLD_LOCATED_CNT()
        {
            return await Task.Run(() => {
                try
                {
                    COM.OraDB MyOraDB = new COM.OraDB();
                    DataSet ds_ret;
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;

                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_LOCATED_CNT";

                    MyOraDB.ReDim_Parameter(2);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                    MyOraDB.Parameter_Name[1] = "ARG_WH_CD";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;

                    MyOraDB.Parameter_Values[0] = "";
                    MyOraDB.Parameter_Values[1] = "10";

                    MyOraDB.Add_Select_Parameter(true);
                    ds_ret = MyOraDB.Exe_Select_Procedure();

                    if (ds_ret == null) return null;
                    return ds_ret.Tables[process_name];
                }
                catch
                {
                    return null;
                }
            });
        }
        private async Task<DataTable> SEL_MOLD_LOCTED_SEARCH()
        {
            return await Task.Run(() => {
                try
                {
                    COM.OraDB MyOraDB = new COM.OraDB();
                    DataSet ds_ret;
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;

                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_LOCTED_SEARCH";

                    MyOraDB.ReDim_Parameter(3);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                    MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                    MyOraDB.Parameter_Name[2] = "ARG_TYPE";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;

                    MyOraDB.Parameter_Values[0] = "";
                    MyOraDB.Parameter_Values[1] = "10";
                    MyOraDB.Parameter_Values[2] = "";

                    MyOraDB.Add_Select_Parameter(true);
                    ds_ret = MyOraDB.Exe_Select_Procedure();

                    if (ds_ret == null) return null;
                    return ds_ret.Tables[process_name];
                }
                catch
                {
                    return null;
                }
            });


        }

        #endregion DB

        #region Event Form
        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_Title_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }

        private void label1_Click(object sender, EventArgs e)
        {

            pnLocation.Controls.Clear();
            InitLocation();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void cmd_Inventory_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "1112";
        }

        private void cbo_MoldCd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                string s = Clipboard.GetText();
                string[] lines = s.Replace("\n", "").Split('\r');


                if (lines.Length - 1 == 1)
                {
                    cbo_MoldCd.ClosePopup();
                    cbo_MoldCd.EditValue = lines[0];
                }
            }

            base.OnKeyDown(e);
        }

        #endregion



        #region Search Location
        private void cmd_Search_Click(object sender, EventArgs e)
        {
            ClearSearch();
            DataTable dtData = GetLocation();
            if (dtData == null) return;
            

            foreach (DataRow row in dtData.Rows)
            {
                string located = row["LOC"].ToString();
                _lstSearch.Add(located);
                LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)_DtnBox[located].Child;
                box.BoxColorSearch();
                box.setBlink(true);
            }

            //List<string> lstData = new List<string>();

            //foreach (DataRow row in dtData.Rows)
            //{
            //    lstData.Add(row["LOC"].ToString());
            //}

            //if (ComparerList(lstData, _lstSearch))
            //{
            //    ClearSearch();

            //    foreach (DataRow row in dtData.Rows)
            //    {
            //        string located = row["LOC"].ToString();
            //        _lstSearch.Add(located);
            //        LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)_DtnBox[located].Child;
            //        box.BoxColorSearch();
            //        box.setBlink(true);
            //    }
            //}


        }

        private bool ComparerList(List<string> lst1, List<string> lst2)
        {
            try
            {
                var listResult = lst1.Except(lst2).ToList();
                return listResult.Any();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return true;
            }
           
        }

        private void ClearSearch()
        {
            try
            {
                if (_lstSearch == null) return;
                foreach (string located in _lstSearch)
                {
                    LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)_DtnBox[located].Child;
                    box.setBlink(false);
                    box.BoxColorDefault();
                    
                }
                _lstSearch.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                _lstSearch.Clear();
                LoadBoxQty();
            }
            
            
        }

        private DataTable GetLocation()
        {
            try
            {
                string model = cbo_Model.Text == "ALL" ? "" : cbo_Model.Text;
                string moldCd = cbo_MoldCd.Text == "ALL" ? "" : cbo_MoldCd.Text;
                string size = cbo_Size.Text == "ALL" ? "" : cbo_Model.Text;
                if (model == "" && moldCd == "")
                {
                    MessageBox.Show("Chon Model Hoac Mold Code");
                    return null;
                }
                DataTable dt = _dt_Combo.Select($"MODEL_NM like '{model}%' and MOLD_CD like '{moldCd}%' and USE_SIZE like '{size}%'").CopyToDataTable();
                return dt.DefaultView.ToTable(true, "LOC");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }

        }



        #endregion Search Location
    }
}
