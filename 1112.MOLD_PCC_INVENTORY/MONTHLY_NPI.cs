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
using WindowsApplication1;

namespace FORM
{
    public partial class MONTHLY_NPI : Form
    {
        public MONTHLY_NPI()
        {
            InitializeComponent();
            
        }
        
        int _time = 0;
        DataTable _dtData = null;
        bool first = true;
        MyCellMergeHelper _Helper;

        #region Load-Visible Change-Timer
        private void SMT_QUALITY_COCKPIT_FORM1_Load(object sender, EventArgs e)
        {
            
        }

        private void SMT_QUALITY_COCKPIT_REWORK_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cmd_Back.Visible = false;
                dtp_DateF.EditValue = DateTime.Now;
                dtp_DateT.EditValue = DateTime.Now;
                InitCombo("C_PLANT", cbo_Factory);
                InitCombo("C_LINE", cbo_Plant, "2110");
                InitCombo("C_MODEL", cbo_Model);

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

            }
        }

        #endregion

        #region Combox

        private async void InitCombo(string type, LookUpEdit cboName, string condition = "")
        {
            DataTable dtData = await P_MSQM90006A_Q_COMBO_H(type, condition);
            SetComboBox(dtData, cboName, true);
        }

        private void SetComboBox(DataTable dtData, LookUpEdit cboName, bool displayMember = false)
        {
            if (cboName.IsPopupOpen) return;

            bool dif = true;
            if (cboName.Properties.DataSource != null)
            {
                dif = CompareDataTable((DataTable)cboName.Properties.DataSource, dtData);
            }
            if (!dif) return;

            if(dtData == null)
            {
                cboName.Properties.DataSource = dtData;
                return;
            }

            string codeName = dtData.Columns[0].ColumnName;
            string displayName = displayMember ? dtData.Columns[1].ColumnName : dtData.Columns[0].ColumnName;

            cboName.Properties.Columns.Clear();
            cboName.Properties.DataSource = dtData;
            cboName.Properties.ValueMember = codeName;
            cboName.Properties.DisplayMember = displayName;
            cboName.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(codeName));
            cboName.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayName));
            cboName.Properties.Columns[codeName].Caption = "CODE";
            cboName.Properties.Columns[codeName].Visible = false;
            cboName.ItemIndex = 0;
        }

        private bool CompareDataTable(DataTable dtData1, DataTable dtData2)
        {
            if (dtData1.Rows.Count != dtData2.Rows.Count) return true;

            var dif = dtData1.AsEnumerable().Except(dtData2.AsEnumerable(), DataRowComparer.Default);

            return dif.Any();
        }

        #endregion Set Data

        private async void LoadData()
        {
            DataTable dtData = await P_MSQM90006A_Q_H(type: "Q_MAIN",
                                                    datef: dtp_DateF.DateTime.ToString("yyyyMM"),
                                                    datet: dtp_DateT.DateTime.ToString("yyyyMM"),
                                                    plant: cbo_Factory.EditValue.ToString(),
                                                    line: cbo_Plant.EditValue.ToString(),
                                                    model: cbo_Model.EditValue.ToString());

            grd_Detail.DataSource = dtData;

            //In case Data in Grid View in wrong position
            for(int i = 0; i <= 3; i++)
            {
                FormatGridData();
            }
            
        }

        #region Event Form
        private void cmd_Search_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Event Grid

        private void FormatGridData()
        {
            try
            {
                gvw_Detail.BeginUpdate();

                if (first)
                {
                    _Helper = new MyCellMergeHelper(gvw_Detail);
                    first = false;
                }

                for (int i = 0; i < gvw_Detail.Columns.Count; i++)
                {
                    gvw_Detail.Columns[i].OptionsColumn.AllowEdit = false;
                    gvw_Detail.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvw_Detail.Columns[i].OptionsFilter.AllowAutoFilter = false;
                    gvw_Detail.Columns[i].OptionsColumn.ReadOnly = true;
                    gvw_Detail.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvw_Detail.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvw_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvw_Detail.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                }

                gvw_Detail.EndUpdate();

                _Helper.removeMerged();
                /*if (first)
                    _Helper = new MyCellMergeHelper(gvwMaster);*/
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 1, 2, "");
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 2, 3, "");
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 3, 4, "");
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 4, 5, "");
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 5, 6, "");
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 6, 7, "");
                _Helper.AddMergedCell(gvw_Detail.RowCount - 1, 7, 8, "");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }


        private void gvw_Detail_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gvw_Detail.RowCount == 0) return;
                e.Merge = false;
                e.Handled = true;

                if(e.Column.FieldName == "FACTORY")
                {
                    string item1 = gvw_Detail.GetRowCellValue(e.RowHandle1, "FACTORY").ToString();
                    string item2 = gvw_Detail.GetRowCellValue(e.RowHandle2, "FACTORY").ToString();

                    if(item1 == item2)
                    {
                        e.Merge = true;
                    }
                }

                if (e.Column.FieldName == "PLANT")
                {
                    string item1 = gvw_Detail.GetRowCellValue(e.RowHandle1, "PLANT").ToString();
                    string item2 = gvw_Detail.GetRowCellValue(e.RowHandle2, "PLANT").ToString();

                    if (item1 == item2)
                    {
                        e.Merge = true;
                    }
                }

                if (e.Column.FieldName == "NPI_SCORE_PLANT")
                {
                    string item1 = gvw_Detail.GetRowCellValue(e.RowHandle1, "PLANT").ToString();
                    string item2 = gvw_Detail.GetRowCellValue(e.RowHandle2, "PLANT").ToString();
                    string item3 = gvw_Detail.GetRowCellValue(e.RowHandle1, "NPI_SCORE_PLANT").ToString();
                    string item4 = gvw_Detail.GetRowCellValue(e.RowHandle2, "NPI_SCORE_PLANT").ToString();

                    if (item1 == item2 && item3 == item4)
                    {
                        e.Merge = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return;
            }
        }

        #endregion

        #region Database
        public async Task<DataTable> P_MSQM90006A_Q_H(string type, string datef, string datet, string plant, string line, string model)
        {
            return await Task.Run(() =>
            {
                COM.OraDB myOraDB = new COM.OraDB();
                myOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                myOraDB.ShowErr = true;
                DataSet dtSet = null;

                try
                {
                    string processName = "P_MSQM90006A_Q_H";
                    myOraDB.Process_Name = processName;
                    myOraDB.ReDim_Parameter(7);

                    myOraDB.Parameter_Name[0] = "V_P_QTYPE";
                    myOraDB.Parameter_Name[1] = "V_P_DATEF";
                    myOraDB.Parameter_Name[2] = "V_P_DATET";
                    myOraDB.Parameter_Name[3] = "V_P_PLANT";
                    myOraDB.Parameter_Name[4] = "V_P_LINE";
                    myOraDB.Parameter_Name[5] = "V_P_MODEL";
                    myOraDB.Parameter_Name[6] = "CV_1";

                    myOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[6] = (int)OracleType.Cursor;

                    myOraDB.Parameter_Values[0] = type;
                    myOraDB.Parameter_Values[1] = datef;
                    myOraDB.Parameter_Values[2] = datet;
                    myOraDB.Parameter_Values[3] = plant;
                    myOraDB.Parameter_Values[4] = line;
                    myOraDB.Parameter_Values[5] = model;
                    myOraDB.Parameter_Values[6] = "";

                    myOraDB.Add_Select_Parameter(true);
                    dtSet = myOraDB.Exe_Select_Procedure();

                    if (dtSet == null) return null;

                    return dtSet.Tables[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            });
        }

        public async Task<DataTable> P_MSQM90006A_Q_COMBO_H(string type, string condition = "")
        {
            return await Task.Run(() =>
            {
                COM.OraDB myOraDB = new COM.OraDB();
                myOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                myOraDB.ShowErr = true;
                DataSet dtSet = null;

                try
                {
                    string processName = "P_MSQM90006A_Q_COMBO_H";
                    myOraDB.Process_Name = processName;
                    myOraDB.ReDim_Parameter(3);

                    myOraDB.Parameter_Name[0] = "V_P_COMBO_TYPE";
                    myOraDB.Parameter_Name[1] = "V_P_CONDITION";
                    myOraDB.Parameter_Name[2] = "CV_1";

                    myOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                    myOraDB.Parameter_Values[0] = type;
                    myOraDB.Parameter_Values[1] = condition;
                    myOraDB.Parameter_Values[2] = "";

                    myOraDB.Add_Select_Parameter(true);
                    dtSet = myOraDB.Exe_Select_Procedure();

                    if (dtSet == null) return null;

                    return dtSet.Tables[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            });
        }


        #endregion Database

        private void lblDate_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbo_Factory_EditValueChanged(object sender, EventArgs e)
        {
            string check = cbo_Factory.EditValue.ToString();
            InitCombo("C_LINE", cbo_Plant, check);
        }

        private void gvw_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "NPI_SCORE_PLANT" || e.Column.FieldName == "NPI_SCORE_LINE")
            {
                e.DisplayText = e.CellValue + "%";
                if (Convert.ToInt32(e.CellValue) >= 100)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (Convert.ToInt32(e.CellValue) >= 90 && Convert.ToInt32(e.CellValue) <= 99)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if (Convert.ToInt32(e.CellValue) < 90)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            if (e.Column.FieldName == "NPI_SCORE_PLANT")
            {
                e.DisplayText = e.CellValue + "%";
            }
        }
    }
}