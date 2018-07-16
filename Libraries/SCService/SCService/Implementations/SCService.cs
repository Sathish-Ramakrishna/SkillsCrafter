using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SkillsCrafter.SCProxy;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SkillsCrafter.SCShared.Utilities;
using SkillsCrafter.SCService.Contracts;

namespace SkillsCrafter.SCService.Implementations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    public class SCService : ILoginService, IMainService
    {
        string CS = ConfigurationManager.ConnectionStrings["SQLCS"].ConnectionString;
        public int Login(ref ActionContext actionContext, string username, byte[] password)
        {
            int returntype = 0;
            int flag = 0;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                SqlParameter param;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetResources";

                param = new SqlParameter("@Username", username);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string uname = dr["Username"].ToString();
                        byte[] pwsd = (byte[])dr["Password"];
                        string rType = dr["ResourceType"].ToString();

                        if (uname.Equals(username) && pwsd.SequenceEqual(password))
                        {
                            flag = 1;
                            if (rType.Equals("E")) { return 1; }
                            else if (rType.Equals("M")) { return 2; }
                            else if (rType.Equals("A")) { return 3; }
                        }
                        else
                            actionContext.Error = "Invalid Username or Password";

                    }
                    if (flag == 0)
                    {
                        return 0;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    returntype = 0;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Dispose();
                    conn.Close();
                }
                return returntype;
            }
        }

        public DataTable getSkillsDefinitions(ref ActionContext actionContext, string product)
        {
            DataTable dtbl = new DataTable();
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(CS))
            //    {
            //        conn.Open();
            //        SqlDataAdapter sda = new SqlDataAdapter("SELECT SkillType, Name, Beginner, Intermediate, Proficient, Advanced, Expert FROM SkillsDefinitions WHERE PRODUCTNAME = '" + product + "'", conn);
            //        sda.Fill(dtbl);
            //        conn.Close();
            //    }

            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    actionContext.Error = ex.Errors.ToString();
            //}
            //return dtbl;

            try
            {

                using (SqlConnection conn = new SqlConnection(CS))
                {
                SqlCommand cmd = new SqlCommand();
                SqlParameter param;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                cmd.CommandText = "sp_GetSkillsDefinitions";

                param = new SqlParameter("@ProductName", product);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                cmd.Parameters.Add(param);

                cmd.Connection = conn;
                  conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //dtbl.Load(dr);

                    DataTable dtSchema = dr.GetSchemaTable();
                    // You can also use an ArrayList instead of List<> 
                    List<DataColumn> listCols = new List<DataColumn>();
                    if (dtSchema != null)
                    {
                        foreach (DataRow drow in dtSchema.Rows)
                        {
                            string columnName = System.Convert.ToString(drow["ColumnName"]);
                            DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                            column.Unique = (bool)drow["IsUnique"];
                            column.AllowDBNull = (bool)drow["AllowDBNull"];
                            column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                            listCols.Add(column);
                            dtbl.Columns.Add(column);
                        }

                    }

                    // Read rows from DataReader and populate the DataTable 
                    while (dr.Read())
                    {
                        DataRow dataRow = dtbl.NewRow();
                        for (int i = 0; i < listCols.Count; i++)
                        {
                            dataRow[((DataColumn)listCols[i])] = dr[i];
                        }

                        dtbl.Rows.Add(dataRow);
                    }
                
            }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //finally
            //{
            //    cmd.Dispose();
            //    conn.Dispose();
            //    conn.Close();
            //}
            return dtbl;
        }
    }
}


