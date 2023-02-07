using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System;
using System.Reflection.PortableExecutable;
using System.Data.Common;


public class DbQueryUtil
{
    public static SqlCommand ExecuteQuery(string query, bool cls=true)
    {
        SqlCommand sqlCommand = new SqlCommand();
        string connetionString;
        SqlConnection cnn;
        connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\settle\source\repos\OxygenCylinderAgency\OxygenCylinderAgency\OxyDb.mdf;Integrated Security=True";
        cnn = new SqlConnection(connetionString);
        if (cnn != null && cnn.State == ConnectionState.Closed)
        {
            cnn.Open();
        }
        try
        {
            // Settings.  
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = cnn;
            sqlCommand.CommandTimeout = 12 * 3600;
            //// Setting timeeout for longer queries to 12 hours.  
            if (cls)
            {
                cnn.Close();
            }

            return sqlCommand;
        }
        catch (Exception ex)
        {
            // Close.  
            cnn.Close();
            MessageBox.Show(ex.Message);
            throw ex;
        }
    }
}
