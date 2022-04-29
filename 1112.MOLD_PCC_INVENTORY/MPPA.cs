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
    public partial class MPPA : Form
    {
        public MPPA()
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
                cmd_Back.Visible = false;
                dtp_DateF.EditValue = DateTime.Now;
                dtp_DateT.EditValue = DateTime.Now;
                initCombo("C_PLANT", cbo_Factory);
                initCombo("C_LINE", cbo_Plant, "2110");
                initCombo("C_MODEL", cbo_Model);


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

        public async void initCombo(string type, LookUpEdit cboName, string condition = "")
        {
            DataTable dtData = await P_MSQM90024A_Q_COMBO_H(type, condition);
            SetComboBox(dtData, cboName, true);
        }

        private void SetComboBox(DataTable dtData, LookUpEdit cboName, bool displayMember = false)
        {
            bool dif = true;

            if (cboName.IsPopupOpen) return;

            if(cboName.Properties.DataSource != null)
            {
                dif = CompareDataTable(dtData, (DataTable)cboName.Properties.DataSource);
            }
            if (!dif) return;
            if(dtData == null)
            {
                cboName.Properties.DataSource = null;
                return;
            }

            string codeValue = dtData.Columns[0].ColumnName;
            string nameValue = displayMember ? dtData.Columns[1].ColumnName : dtData.Columns[0].ColumnName;

            cboName.Properties.Columns.Clear();
            cboName.Properties.DataSource = dtData;
            cboName.Properties.ValueMember = codeValue;
            cboName.Properties.DisplayMember = nameValue;
            cboName.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(codeValue));
            cboName.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(nameValue));
            cboName.Properties.Columns[codeValue].Caption = "CODE";
            cboName.Properties.Columns[nameValue].Caption = "NAME";
            cboName.Properties.Columns[codeValue].Visible = false;
            cboName.ItemIndex = 0;
        }

        private bool CompareDataTable(DataTable dtData1, DataTable dtData2)
        {
            if (dtData1.Rows.Count != dtData2.Rows.Count) return true;

            var dif = dtData2.AsEnumerable().Except(dtData2.AsEnumerable(), DataRowComparer.Default);
            return dif.Any();
        }

        #endregion Set Data


        #region Event Form
        private void cmd_Search_Click(object sender, EventArgs e)
        {
            LoadData();
            FormatGrid();
        }

        private async void LoadData()
        {
            DataTable dtData = await P_MSQM90024A_Q_H("Q2",
                                                      cbo_Factory.EditValue.ToString(),
                                                      dtp_DateF.DateTime.ToString("yyyyMMdd"),
                                                      dtp_DateT.DateTime.ToString("yyyyMMdd"),
                                                      cbo_Plant.EditValue.ToString(),
                                                      cbo_Model.EditValue.ToString());
            if(dtData!= null && dtData.Rows.Count > 0)
            {
                grd_Detail.DataSource = dtData;
            }
        }

        #endregion

        #region Event Grid

        private void FormatGrid()
        {
            grd_Detail.BeginUpdate();

            for(int i = 0; i < gvw_Detail.Columns.Count; i++)
            {
                gvw_Detail.Columns[i].OptionsColumn.AllowEdit = false;
                gvw_Detail.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvw_Detail.Columns[i].OptionsColumn.ReadOnly = true;
                gvw_Detail.Columns[i].OptionsFilter.AllowFilter = false;
                gvw_Detail.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvw_Detail.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gvw_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvw_Detail.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                if (gvw_Detail.Columns[i].FieldName.Equals("CATEGORY_NM") || gvw_Detail.Columns[i].FieldName.Equals("MODEL_NM") || gvw_Detail.Columns[i].FieldName.Equals("PEAC_ISSUE"))
                {
                    gvw_Detail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }

            }

            gvw_Detail.TopRowIndex = 0;
            grd_Detail.EndUpdate();
        }

        #endregion

        #region Database

        public async Task<DataTable> P_MSQM90024A_Q_COMBO_H(string V_P_COMBO_TYPE, string V_P_CONDITION = "")
        {
            return await Task.Run(() =>
            {
                COM.OraDB myOraDB = new COM.OraDB();
                myOraDB.ShowErr = true;
                DataSet dtSet = null;

                try
                {
                    myOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                    string proName = "LMES.P_MSQM90024A_Q_COMBO_H";
                    myOraDB.Process_Name = proName;
                    myOraDB.ReDim_Parameter(3);

                    myOraDB.Parameter_Name[0] = "V_P_COMBO_TYPE";
                    myOraDB.Parameter_Name[1] = "V_P_CONDITION";
                    myOraDB.Parameter_Name[2] = "CV_1";

                    myOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                    myOraDB.Parameter_Values[0] = V_P_COMBO_TYPE;
                    myOraDB.Parameter_Values[1] = V_P_CONDITION;
                    myOraDB.Parameter_Values[2] = "";

                    myOraDB.Add_Select_Parameter(true);
                    dtSet = myOraDB.Exe_Select_Procedure();

                    if (dtSet == null) return null;
                    return dtSet.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            });
        }

        public async Task<DataTable> P_MSQM90024A_Q_H(string V_P_QTYPE, string V_P_FACTORY, string V_P_DATEF, string V_P_DATET, string V_P_LINE, string V_P_MODEL)
        {
            return await Task.Run(() =>
            {
                COM.OraDB myOraDB = new COM.OraDB();
                myOraDB.ShowErr = true;
                DataSet dtSet = null;

                try
                {
                    myOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                    string proName = "LMES.P_MSQM90024A_Q_H";
                    myOraDB.Process_Name = proName;
                    myOraDB.ReDim_Parameter(8);

                    myOraDB.Parameter_Name[0] = "V_P_QTYPE";
                    myOraDB.Parameter_Name[1] = "V_P_FACTORY";
                    myOraDB.Parameter_Name[2] = "V_P_DATEF";
                    myOraDB.Parameter_Name[3] = "V_P_DATET";
                    myOraDB.Parameter_Name[4] = "V_P_LINE";
                    myOraDB.Parameter_Name[5] = "V_P_MODEL";
                    myOraDB.Parameter_Name[6] = "CV_1";
                    myOraDB.Parameter_Name[7] = "CV_2";

                    myOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                    myOraDB.Parameter_Type[6] = (int)OracleType.Cursor;
                    myOraDB.Parameter_Type[7] = (int)OracleType.Cursor;

                    myOraDB.Parameter_Values[0] = V_P_QTYPE;
                    myOraDB.Parameter_Values[1] = V_P_FACTORY;
                    myOraDB.Parameter_Values[2] = V_P_DATEF;
                    myOraDB.Parameter_Values[3] = V_P_DATET;
                    myOraDB.Parameter_Values[4] = V_P_LINE;
                    myOraDB.Parameter_Values[5] = V_P_MODEL;
                    myOraDB.Parameter_Values[6] = "";
                    myOraDB.Parameter_Values[7] = "";

                    myOraDB.Add_Select_Parameter(true);
                    dtSet = myOraDB.Exe_Select_Procedure();

                    if (dtSet == null) return null;
                    return dtSet.Tables[0];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
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
            string _factory = cbo_Factory.EditValue.ToString();
            initCombo("C_LINE", cbo_Plant, _factory);
        }

        private void gvw_Detail_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.RowHandle1 < 0 || gvw_Detail.RowCount == 0) return;

            e.Handled = true;
            e.Merge = false;
        }

        private void gvw_Detail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName == "PEAC_RANK_NM" || e.Column.FieldName == "FDPA_RANK_NM" || e.Column.FieldName == "FINAL")
            {
                if(Convert.ToString(e.CellValue) == "Excellent")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }else if (Convert.ToString(e.CellValue) == "Acceptable")
                {
                    e.Appearance.BackColor = Color.LightYellow;

                    
                } else if (Convert.ToString(e.CellValue) == "Inconsistant")
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (Convert.ToString(e.CellValue) == "Fail")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
    }
}