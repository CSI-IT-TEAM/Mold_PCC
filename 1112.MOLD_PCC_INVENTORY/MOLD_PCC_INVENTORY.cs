using DevExpress.XtraCharts;
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
                SetDataGrid();
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
                SetDataGrid();

            }
        }

        #endregion

        #region Set Data
        private async void SetDataGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtData = await SEL_MOLD_INVENTORY();
                gvw_Detail.BeginUpdate();
                grd_Detail.DataSource = dtData;

                for (int i = 0; i < gvw_Detail.Columns.Count; i++)
                {
                    gvw_Detail.Columns[i].AppearanceCell.Font = new Font("Calibri", 16, FontStyle.Bold);
                    gvw_Detail.Columns[i].AppearanceCell.Options.UseTextOptions = true;
                    gvw_Detail.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gvw_Detail.Columns[i].OptionsFilter.AllowFilter = false;
                    gvw_Detail.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvw_Detail.Columns[i].OptionsColumn.AllowEdit = false;
                    gvw_Detail.Columns[i].OptionsColumn.ReadOnly = true;

                    if (i>1)
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
        }


        #endregion

        #region Database
        public async Task<DataTable> SEL_MOLD_INVENTORY()
        {
            return await Task.Run(() => {
                COM.OraDB MyOraDB = new COM.OraDB();
                DataSet ds_ret;
                try
                {
                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_INVENTORY";
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                    MyOraDB.ReDim_Parameter(3);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                    MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                    MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                    MyOraDB.Parameter_Values[0] = "10";
                    MyOraDB.Parameter_Values[1] = "";
                    MyOraDB.Parameter_Values[2] = "";

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

    }
}
