using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class MOLD_PCC_POP_DETAIL : Form
    {
        public MOLD_PCC_POP_DETAIL()
        {
            InitializeComponent();
        }
        public string _location="";

        public Hashtable _htInfor = null;

        private async void SetData()
        {
            try
            {
                gridControl1.DataSource = await SEL_MOLD_LOCTED_POP_DETAIL("","","");

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {

                    gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    if (i <= 1)
                    {
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        
                    }
                    else
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }           
        }

        #region DB
        private async Task<DataTable> SEL_MOLD_LOCTED_POP_DETAIL(string arg_Type,string arg_MoldCd,string arg_Located)
        {
            return await Task.Run(() => {
                try
                {
                    COM.OraDB MyOraDB = new COM.OraDB();
                    DataSet ds_ret;
                    MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;

                    string process_name = "PKG_MSPD_MOLD_PCC_WMS.SEL_MOLD_POP_DETAIL";

                    MyOraDB.ReDim_Parameter(5);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                    MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                    MyOraDB.Parameter_Name[2] = "ARG_LOCATED";
                    MyOraDB.Parameter_Name[3] = "ARG_TYPE";
                    MyOraDB.Parameter_Name[4] = "ARG_MOLD_CD";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;

                    MyOraDB.Parameter_Values[0] = "";
                    MyOraDB.Parameter_Values[1] = "10";
                    MyOraDB.Parameter_Values[2] = arg_Located;
                    MyOraDB.Parameter_Values[3] = arg_Type;
                    MyOraDB.Parameter_Values[4] = arg_MoldCd;

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


        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SetData();
            }
            else
            {
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveDlg = new SaveFileDialog())
            {
                SaveDlg.RestoreDirectory = true;
                SaveDlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(SaveDlg.FileName);
                }


            }
        }
    }
}
