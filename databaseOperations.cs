using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignement_3_Testing
{
    public class databaseOperations
    {
    
    private static string getConnectionString()
    {
        string host = "Host=localhost;";
        string port = "Port=5432;";
        string dbName = "Database=Farmer_Market;";
        string userName = "Username=postgres;";
        string password = "Password=1234;";

        string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
        return connectionString;
    }

    public static NpgsqlConnection con;

    public static NpgsqlCommand cmd;

        private static void establishConnection()
        {
            try
            {
                con = new NpgsqlConnection(getConnectionString());


                MessageBox.Show("Database Connection is Successful");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void AddData(string product_name, int product_id, int amount_kg, double price_cad_kg)
    {
            establishConnection();
        con.Open();
        string query = "insert into products values(@product_Name, @product_id, @amount_kg, @price_cad_kg)";

        cmd = new NpgsqlCommand(query, con);
        cmd.Parameters.AddWithValue("@product_name", product_name);
        cmd.Parameters.AddWithValue("@product_id", product_id);
        cmd.Parameters.AddWithValue("@amount_kg", amount_kg);
        cmd.Parameters.AddWithValue("@price_cad_kg", price_cad_kg);

        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            MessageBox.Show("Data inserted succesfully");
        }
        con.Close();
    }

    public static string[] selectLastData(int id)
    {
            establishConnection();
        con.Open();
        string Query = "select * from products where @product_id=id";
        cmd = new NpgsqlCommand(@Query, con);
        cmd.Parameters.AddWithValue(@"id", id);

        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);


        string[] dataRetrive = new string[4];

        if (dt.Rows.Count > 0)
        {
            dataRetrive[0] = (string)dt.Rows[0][0];
            dataRetrive[1] = dt.Rows[0][1].ToString();
            dataRetrive[2] = dt.Rows[0][2].ToString();
            dataRetrive[3] = dt.Rows[0][3].ToString();

        }
        return dataRetrive;

    }
}
}