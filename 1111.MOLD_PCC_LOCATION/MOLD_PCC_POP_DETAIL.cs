using DevExpress.XtraGrid.Columns;
using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace FORM
{
    public partial class MOLD_PCC_POP_DETAIL : Form
    {
        public MOLD_PCC_POP_DETAIL()
        {
            InitializeComponent();
        }
        public string _location="";

        string _strHeader = "Shelf ";

        public Hashtable _htInfor = null;
        DataTable _dtData = null;
        bool _isLoad = true;
        enum SelectType
        {
            Model,
        }

        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _isLoad = true;
                lblHeader.Text = _strHeader + _location;
                SetData();
                tmr_Reload.Start();
                _isLoad = false;
            }
            else
            {
                tmr_Reload.Stop();
            }
        }

        private void tmr_Reload_Tick(object sender, EventArgs e)
        {
            SetData();
        }

        private async void SetData(bool arg_Reload = false)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet dsData = await SEL_MOLD_LOCTED_POP_DETAIL("", "", "");
                DataTable dtData = dsData.Tables[0];
                DataTable dtColumn = dsData.Tables[1];
                _dtData = dtData;
               

                if (arg_Reload)
                    grdMain.DataSource = dtData;
                else
                    SetGrid(dtData, dtColumn);
               // SetComboBox(SelectData(dtData, SelectType.Model));
                SetCboModel(SelectData(dtData, SelectType.Model));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }      
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SetGrid(DataTable arg_DtData, DataTable arg_DtColumn)
        {
            gvwMain.BeginUpdate();
            gvwMain.OptionsView.ColumnAutoWidth = false;
            gvwMain.RowHeight = 30;
            grdMain.DataSource = arg_DtData;
            for (int i = 0; i < gvwMain.Columns.Count; i++)
            {
                GridColumn gridColumn = gvwMain.Columns[i];
                //using (GridColumn gridColumn = gvwMain.Columns[i])
                //{
                gridColumn.AppearanceHeader.Font = new Font("Calibri", 15, FontStyle.Bold);
                gridColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gridColumn.AppearanceCell.Font = new Font("Calibri", 13, FontStyle.Regular);
                gridColumn.OptionsColumn.ReadOnly = true;
                gridColumn.OptionsColumn.AllowEdit = false;
                gridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                if (i <= 2)
                {
                    gridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
                else
                    gridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            }

            foreach (DataRow row in arg_DtColumn.Rows)
            {
                GridColumn gridColumn = gvwMain.Columns[row["COL_NAME"].ToString()];
                gridColumn.Caption = row["COL_TEXT"].ToString();
                gridColumn.Visible = row["SHOW_YN"].ToString() == "Y" ? true : false;
                gridColumn.AppearanceCell.TextOptions.HAlignment = row["ALIGN"].ToString() == "L" ?
                                                                    DevExpress.Utils.HorzAlignment.Near : row["ALIGN"].ToString() == "R" ?
                                                                    DevExpress.Utils.HorzAlignment.Far : DevExpress.Utils.HorzAlignment.Center;
            }
            gvwMain.BestFitColumns();
            gvwMain.EndUpdate();
        }

        #region Event Grid
        private void gvwMain_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName.ToString().ToUpper() == "TOTAL")
            //{
            //    e.Appearance.BackColor = Color.LightYellow;
            //    e.Appearance.ForeColor = Color.Blue;
            //    e.Appearance.Font = new Font("Calibri", 13, FontStyle.Bold);

            //}
            if (gvwMain.GetRowCellValue(e.RowHandle, "MODEL_NM").ToString().ToUpper().Equals("TOTAL"))
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Calibri", 14, FontStyle.Bold);
            }

            if (gvwMain.GetRowCellValue(e.RowHandle, "MOLD_CD").ToString().ToUpper().Equals("TOTAL"))
            {
                e.Appearance.BackColor = Color.LightYellow;
                e.Appearance.ForeColor = Color.Blue;
                e.Appearance.Font = new Font("Calibri", 13, FontStyle.Bold);
            }

            //if (e.Column.FieldName.ToString().ToUpper() == "MOLD_CD" || e.Column.FieldName.ToString().ToUpper() == "MODEL_NM")
            //{
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.ForeColor = Color.Black;
            //}
        }

        #endregion

        #region Combobox
        private void cbo_Model_EditValueChanged(object sender, EventArgs e)
        {
           // if (_isLoad) return;
            
        }

        private DataTable SelectData(DataTable arg_Data, SelectType arg_Select)
        {
            try
            {
                DataTable dtData = null;
                if (arg_Select == SelectType.Model)
                {
                    string[] selectedColumns = new[] { "MODEL_NM" };

                    DataTable dt = new DataView(arg_Data).ToTable(true, selectedColumns);
                    dtData = dt.Select("MODEL_NM <>'Total'").Distinct().CopyToDataTable();
                    DataRow dr = dtData.NewRow();
                    dr[0] = "ALL";

                    dtData.Rows.InsertAt(dr, 0);
                }
                return dtData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        private void SetCboModel(DataTable arg_Dt)
        {
            cbo_Model.Properties.Columns.Clear();
            cbo_Model.Properties.DataSource = arg_Dt;
            if (arg_Dt == null) return;
            cbo_Model.Properties.ValueMember = arg_Dt.Columns[0].ColumnName;
            cbo_Model.Properties.DisplayMember = arg_Dt.Columns[0].ColumnName;
            cbo_Model.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(arg_Dt.Columns[0].ColumnName));
            //cbo_Model.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(arg_Dt.Columns[1].ColumnName));
            //cbo_Model.Properties.Columns[arg_Dt.Columns[0].ColumnName].Visible = false;
            cbo_Model.ItemIndex = 0;
        }


        private DataTable CboModelValueChange()
        {
            try
            {
                DataTable dtData = null;
                dtData = cbo_Model.Text == "ALL" ? _dtData : _dtData.Select($"MODEL_NM like '{cbo_Model.Text}%'").Distinct().CopyToDataTable();
  
                return dtData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }



        #endregion

        #region Export Excel
        private void grdMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cmnuExcel.Show(grdMain, new Point(e.X, e.Y));
            }
        }

        private void cmnuExcel_MouseClick(object sender, MouseEventArgs e)
        {
            ExportExcel();
        }

        private void ExportExcel()
        {
            using (SaveFileDialog SaveDlg = new SaveFileDialog())
            {
                SaveDlg.RestoreDirectory = true;
                SaveDlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    gvwMain.ExportToXlsx(SaveDlg.FileName);
                }


            }
        }
        #endregion

        #region DB
        private async Task<DataSet> SEL_MOLD_LOCTED_POP_DETAIL(string arg_Type,string arg_MoldCd,string arg_Located)
        {
            return await Task.Run(() => {
                try
                {
                    COM.OraDB MyOraDB = new COM.OraDB();
                    DataSet ds_ret;
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                    MyOraDB.ShowErr = true;
                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_POP_DETAIL";

                    MyOraDB.ReDim_Parameter(6);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                    MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                    MyOraDB.Parameter_Name[2] = "ARG_LOCATED";
                    MyOraDB.Parameter_Name[3] = "ARG_TYPE";
                    MyOraDB.Parameter_Name[4] = "ARG_MOLD_CD";
                    MyOraDB.Parameter_Name[5] = "OUT_CURSOR2";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;


                    MyOraDB.Parameter_Values[0] = "";
                    MyOraDB.Parameter_Values[1] = "10";
                    MyOraDB.Parameter_Values[2] = _location;
                    MyOraDB.Parameter_Values[3] = arg_Type;
                    MyOraDB.Parameter_Values[4] = arg_MoldCd;
                    MyOraDB.Parameter_Values[5] = "";

                    MyOraDB.Add_Select_Parameter(true);
                    ds_ret = MyOraDB.Exe_Select_Procedure();

                    if (ds_ret == null) return null;
                    return ds_ret;
                }
                catch
                {
                    return null;
                }
            });


        }

        #endregion DB

        private void cbo_Model_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            grdMain.DataSource = CboModelValueChange();
        }
    }
}
