using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class MOLD_PCC_INVENTORY : Form
    {
        public MOLD_PCC_INVENTORY()
        {
            InitializeComponent();
            
        }

        int _time = 0;
        DataTable _dtData = null;
        #region Load-Visible Change-Timer
        private void SMT_QUALITY_COCKPIT_FORM1_Load(object sender, EventArgs e)
        {
            
        }

        private void SMT_QUALITY_COCKPIT_REWORK_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cmd_Back.Visible = ComVar.Var._IsBack;
                dtp_Ym.EditValue = DateTime.Now;
                InitCombo();
                LoadData();
                FormatGrid();
                _time = 0;
                tmr_Time.Start();
            }
            else
            {
                tmr_Time.Stop();
            }

        }

        private void tmr_Time_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if (_time >= 40)
            {
                _time = 0;
                LoadData();

            }
        }

        #endregion

        #region Combox
        private async void InitCombo()
        {
            DataTable dt = await SEL_MOLD_INVENTORY(arg_Type:"AREA");
            SetCombobox(dt, cbo_Area, true);
            
        }
        private void SetCombobox(DataTable arg_Dt, LookUpEdit arg_Cbo, bool displayMember = false)
        {
            try
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

                string ColumnCode = arg_Dt.Columns[0].ColumnName;
                string columnName = displayMember ? arg_Dt.Columns[1].ColumnName : arg_Dt.Columns[0].ColumnName;

                arg_Cbo.Properties.Columns.Clear();
                arg_Cbo.Properties.DataSource = arg_Dt;
                arg_Cbo.Properties.ValueMember = ColumnCode;
                arg_Cbo.Properties.DisplayMember = columnName;
                arg_Cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(columnName));
                arg_Cbo.ItemIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
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

        private DataTable GetDataModel(DataTable arg_Dt)
        {
            try
            {
                DataTable dt = arg_Dt.DefaultView.ToTable(true, "MODEL_NM").Copy();
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

        private void cbo_Area_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

        }

        private void cbo_Model_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SetDataGrid(GetDataGrid());
        }

        #endregion

        #region Set Data

        private async void LoadData()
        {
            try
            {
                _dtData = await SEL_MOLD_INVENTORY(arg_Area: cbo_Area.EditValue == null ? "" : cbo_Area.EditValue.ToString()
                                                          , arg_Month: dtp_Ym.DateTime.ToString("yyyyMM"));
                SetCombobox(GetDataModel(_dtData), cbo_Model);
                SetDataGrid(GetDataGrid());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
        }
        private void SetDataGrid(DataTable arg_DtData)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                gvw_Detail.BeginUpdate();
                grd_Detail.DataSource = arg_DtData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                gvw_Detail.EndUpdate();
            }
        }

        private void FormatGrid()
        {
            for (int i = 0; i < gvw_Detail.Columns.Count; i++)
            {
                gvw_Detail.Columns[i].AppearanceCell.Font = new Font("Calibri", 16, FontStyle.Bold);
                gvw_Detail.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                gvw_Detail.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                gvw_Detail.Columns[i].OptionsFilter.AllowFilter = false;
                gvw_Detail.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvw_Detail.Columns[i].OptionsColumn.AllowEdit = false;
                gvw_Detail.Columns[i].OptionsColumn.ReadOnly = true;

                if (i > 1)
                {
                    gvw_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    gvw_Detail.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvw_Detail.Columns[i].DisplayFormat.FormatString = "#,###.##";
                }
                else
                {
                    gvw_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }


            }
        }

        private DataTable GetDataGrid()
        {
            try
            {
                if (cbo_Model.EditValue == null || cbo_Model.EditValue.ToString() == "ALL") return _dtData;
                DataTable dtData = _dtData.Select($"MODEL_NM = '{cbo_Model.EditValue}'").CopyToDataTable();
                return dtData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            
        }


        #endregion Set Data

        #region Event Form

        private void cmd_Back_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }


        #endregion

        #region Event Grid
        private void gvwDetail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }



        private void gvwDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvw_Detail.GetRowCellValue(e.RowHandle, "MODEL_NM").ToString().ToUpper().Equals("TOTAL"))
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Calibri", 14, FontStyle.Bold);
            }
        }


        #endregion

        #region Database
        public async Task<DataTable> SEL_MOLD_INVENTORY(string arg_Month = "", string arg_Area = "", string arg_Type = "SEARCH")
        {
            return await Task.Run(() => {
                COM.OraDB MyOraDB = new COM.OraDB();
                DataSet ds_ret;
                MyOraDB.ShowErr = true;
                try
                {
                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_INVENTORY";
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                    MyOraDB.ReDim_Parameter(4);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                    MyOraDB.Parameter_Name[1] = "ARG_MONTH";
                    MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                    MyOraDB.Parameter_Name[3] = "ARG_AREA";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                    MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;

                    MyOraDB.Parameter_Values[0] = arg_Type;
                    MyOraDB.Parameter_Values[1] = arg_Month;
                    MyOraDB.Parameter_Values[2] = "";
                    MyOraDB.Parameter_Values[3] = arg_Area.Trim();

                    MyOraDB.Add_Select_Parameter(true);
                    ds_ret = MyOraDB.Exe_Select_Procedure();

                    if (ds_ret == null) return null;
                    return ds_ret.Tables[0];
                }
                catch
                {
                    return null;
                }
            });
        }



        #endregion Database

        private void gvw_Detail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.AbsoluteIndex >= 2)
                {
                    
                    MOLD_PCC_INVENTORY_DETAIL popup = new MOLD_PCC_INVENTORY_DETAIL();
                    popup._model = gvw_Detail.GetRowCellValue(e.RowHandle, gvw_Detail.Columns["MODEL_NM"]).ToString();
                    popup._mold_cd = gvw_Detail.GetRowCellValue(e.RowHandle, gvw_Detail.Columns["MOLD_CODE"]).ToString();
                    popup._type = e.Column.FieldName;
                    popup._month = dtp_Ym.DateTime.ToString("yyyyMM");
                    popup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
            //gvw_Detail.GetRowCellValue(e.RowHandle, e.Column.FieldName);
        }

        private void cmd_NPI_Click(object sender, EventArgs e)
        {
            MONTHLY_NPI pop = new MONTHLY_NPI();
            pop.ShowDialog();
        }

        private void cmd_MPPA_Click(object sender, EventArgs e)
        {
            MPPA pop = new MPPA();
            pop.ShowDialog();
        }
    }
}
