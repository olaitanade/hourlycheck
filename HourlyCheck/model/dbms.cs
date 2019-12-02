using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourlyCheck.model
{
    public class dbms
    {
        string dbnm = "";
        public SQLiteConnection dbConnection;

        public dbms(string db)
        {
            dbnm = db;
        }

        public void createdb()
        {
            SQLiteConnection.CreateFile(dbnm);

        }

        public void connect(string dbname)
        {
            dbConnection = new SQLiteConnection("Data Source=" + dbname);
            dbConnection.Open();
        }

        public void close()
        {
            dbConnection.Close();
        }

        public void createTable()
        {
            string sql = "create table hourlycheck (date varchar(20) not null unique, H1 varchar(20), H2 varchar(20), H3 varchar(20), H4 varchar(20), H5 varchar(20), H6 varchar(20), H7 varchar(20), H8 varchar(20), H9 varchar(20), H10 varchar(20), H11 varchar(20), H12 varchar(20), H13 varchar(20), H14 varchar(20), H15 varchar(20), H16 varchar(20), H17 varchar(20), H18 varchar(20), H19 varchar(20), H20 varchar(20), H21 varchar(20), H22 varchar(20), H23 varchar(20), H24 varchar(20), Initials varchar(20), Tc integer)";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            command.ExecuteNonQuery();
        }

        public void updateDt(string h1, string h2, string h3, string h4, string h5, string h6, string h7, string h8, string h9, string h10, string h11, string h12, string h13, string h14, string h15, string h16, string h17, string h18, string h19, string h20, string h21, string h22, string h23, string h24, string initials, int tc, string dt)
        {
            string sql = string.Format("UPDATE hourlycheck SET H1 = '{0}', H2 = '{1}', H3 = '{2}', H4 = '{3}', H5 = '{4}', H6 = '{5}', H7 = '{6}', H8 = '{7}', H9 = '{8}', H10 = '{9}', H11 = '{10}', H12 = '{11}', H13 = '{12}', H14 = '{13}', H15 = '{14}', H16 = '{15}', H17 = '{16}', H18 = '{17}', H19 = '{18}', H20 = '{19}', H21 = '{20}', H22 = '{21}', H23 = '{22}', H24 = '{23}', Initials = '{24}', Tc = {25} WHERE date = '{26}';",h1,h2,h3,h4,h5,h6,h7,h8,h9,h10,h11,h12,h13,h14,h15,h16,h17,h18,h19,h20,h21,h22,h23,h24,initials,tc,dt);
            SQLiteCommand c = new SQLiteCommand(sql, dbConnection);
            c.ExecuteNonQuery();
            //dbConnection.Close();

        }

        public void deleteDt(string dt)
        {
            string sql = string.Format("DELETE FROM hourlycheck WHERE date = '{0}';", dt);
            SQLiteCommand c = new SQLiteCommand(sql, dbConnection);
            c.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void insertDt(string dt, string h1, string h2, string h3, string h4, string h5, string h6, string h7, string h8, string h9, string h10, string h11, string h12, string h13, string h14, string h15, string h16, string h17, string h18, string h19, string h20, string h21, string h22, string h23, string h24, string ini,int tc)
        {
            string sql = "insert into hourlycheck (date, H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, H11, H12, H13, H14, H15, H16, H17, H18, H19, H20, H21, H22, H23, H24, Initials, Tc) values (@dd, @h1, @h2, @h3, @h4, @h5, @h6, @h7, @h8, @h9, @h10, @h11, @h12, @h13, @h14, @h15, @h16, @h17, @h18, @h19, @h20, @h21, @h22, @h23, @h24, @init, @tc)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.Prepare();
            command.Parameters.AddWithValue("@dd", dt);
            command.Parameters.AddWithValue("@h1", h1);
            command.Parameters.AddWithValue("@h2", h2);
            command.Parameters.AddWithValue("@h3", h3);
            command.Parameters.AddWithValue("@h4", h4);
            command.Parameters.AddWithValue("@h5", h5);
            command.Parameters.AddWithValue("@h6", h6);
            command.Parameters.AddWithValue("@h7", h7);
            command.Parameters.AddWithValue("@h8", h8);
            command.Parameters.AddWithValue("@h9", h9);
            command.Parameters.AddWithValue("@h10", h10);
            command.Parameters.AddWithValue("@h11", h11);
            command.Parameters.AddWithValue("@h12", h12);
            command.Parameters.AddWithValue("@h13", h13);
            command.Parameters.AddWithValue("@h14", h14);
            command.Parameters.AddWithValue("@h15", h15);
            command.Parameters.AddWithValue("@h16", h16);
            command.Parameters.AddWithValue("@h17", h17);
            command.Parameters.AddWithValue("@h18", h18);
            command.Parameters.AddWithValue("@h19", h19);
            command.Parameters.AddWithValue("@h20", h20);
            command.Parameters.AddWithValue("@h21", h21);
            command.Parameters.AddWithValue("@h22", h22);
            command.Parameters.AddWithValue("@h23", h23);
            command.Parameters.AddWithValue("@h24", h24);
            command.Parameters.AddWithValue("@init", ini);
            command.Parameters.AddWithValue("@tc", tc);
      
            int result = command.ExecuteNonQuery();

            dbConnection.Close();
            
        }

        public SQLiteDataReader getDt()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }


    }
}
