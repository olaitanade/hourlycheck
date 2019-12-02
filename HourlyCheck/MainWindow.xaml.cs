using HourlyCheck.model;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HourlyCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ObservableCollection<Hc> dList = new ObservableCollection<Hc>();
        Hc n = new Hc();
        int no = 0;
        DataSet ds = new DataSet();
        string cDate = "";
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            dbms mydb = new dbms("HCdb.sqlite");
            
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (dt.SelectedDate == null)
            {
                MessageBox.Show("Enter the date");
            }
            else
            {
                if (string.IsNullOrEmpty(initialTb.Text))
                {
                    MessageBox.Show("Enter your initials");
                }
                else
                {
                    Hc ne = n;
                    ne.Dt = (DateTime)dt.SelectedDate;
                    ne.Initials = initialTb.Text;
                    ne.Id = no;
                    
                    try
                    {
                        dbms d = new dbms(@"HCdb.sqlite");
                        d.connect(@"HCdb.sqlite");
                        d.insertDt(ne.Dt.ToShortDateString(),ne.H1,ne.H2,ne.H3,ne.H4,ne.H5,ne.H6,ne.H7,ne.H8,ne.H9,ne.H10,ne.H11,ne.H12,ne.H13,ne.H14,ne.H15,ne.H16,ne.H17,ne.H18,ne.H19,ne.H20,ne.H21,ne.H22,ne.H23,ne.H24,ne.Initials,ne.Tc);
                        try
                        {
                            string sql = "select * from hourlycheck;";
                            ds = new DataSet();
                            var da = new SQLiteDataAdapter(sql, d.dbConnection);
                            da.Fill(ds);
                            hclist.ItemsSource = ds.Tables[0].DefaultView;
                            d.close();
                        }
                        catch (Exception mye)
                        {
                            MessageBox.Show(mye.Message);
                        }
                        dt.Text = null;
                        h1.IsChecked = false;
                        h2.IsChecked = false;
                        h3.IsChecked = false;
                        h4.IsChecked = false;
                        h5.IsChecked = false;
                        h6.IsChecked = false;
                        h7.IsChecked = false;
                        h8.IsChecked = false;
                        h9.IsChecked = false;
                        h10.IsChecked = false;
                        h11.IsChecked = false;
                        h12.IsChecked = false;
                        h13.IsChecked = false;
                        h14.IsChecked = false;
                        h15.IsChecked = false;
                        h16.IsChecked = false;
                        h17.IsChecked = false;
                        h18.IsChecked = false;
                        h19.IsChecked = false;
                        h20.IsChecked = false;
                        h21.IsChecked = false;
                        h22.IsChecked = false;
                        h23.IsChecked = false;
                        h24.IsChecked = false;
                        initialTb.Text = "";
                        n = new Hc();
                        tbshow.IsSelected = true;
                        no++;
                    }
                    catch (Exception myE)
                    {
                        MessageBoxResult d = MessageBox.Show("Record already exist, do you want to update?", "Are you sure", MessageBoxButton.YesNo);
                        if (d == MessageBoxResult.Yes)
                        {
                            dbms dd = new dbms(@"HCdb.sqlite");
                            dd.connect(@"HCdb.sqlite");
                            dd.updateDt(ne.H1, ne.H2, ne.H3, ne.H4, ne.H5, ne.H6, ne.H7, ne.H8, ne.H9, ne.H10, ne.H11, ne.H12, ne.H13, ne.H14, ne.H15, ne.H16, ne.H17, ne.H18, ne.H19, ne.H20, ne.H21, ne.H22, ne.H23, ne.H24, initialTb.Text,ne.Tc,dt.Text);
                            string sql = "select * from hourlycheck;";
                            ds = new DataSet();
                            var da = new SQLiteDataAdapter(sql, dd.dbConnection);
                            da.Fill(ds);
                            hclist.ItemsSource = ds.Tables[0].DefaultView;
                            dd.close();

                            dt.Text = null;
                            h1.IsChecked = false;
                            h2.IsChecked = false;
                            h3.IsChecked = false;
                            h4.IsChecked = false;
                            h5.IsChecked = false;
                            h6.IsChecked = false;
                            h7.IsChecked = false;
                            h8.IsChecked = false;
                            h9.IsChecked = false;
                            h10.IsChecked = false;
                            h11.IsChecked = false;
                            h12.IsChecked = false;
                            h13.IsChecked = false;
                            h14.IsChecked = false;
                            h15.IsChecked = false;
                            h16.IsChecked = false;
                            h17.IsChecked = false;
                            h18.IsChecked = false;
                            h19.IsChecked = false;
                            h20.IsChecked = false;
                            h21.IsChecked = false;
                            h22.IsChecked = false;
                            h23.IsChecked = false;
                            h24.IsChecked = false;
                            initialTb.Text = "";
                            n = new Hc();
                            tbshow.IsSelected = true;
                        }
                        else if (d == MessageBoxResult.No)
                        {

                        }
                    }
                    n = new Hc();

                }
            }

            
            


        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            dt.Text = null;
            h1.IsChecked = false;
            h2.IsChecked = false;
            h3.IsChecked = false;
            h4.IsChecked = false;
            h5.IsChecked = false;
            h6.IsChecked = false;
            h7.IsChecked = false;
            h8.IsChecked = false;
            h9.IsChecked = false;
            h10.IsChecked = false;
            h11.IsChecked = false;
            h12.IsChecked = false;
            h13.IsChecked = false;
            h14.IsChecked = false;
            h15.IsChecked = false;
            h16.IsChecked = false;
            h17.IsChecked = false;
            h18.IsChecked = false;
            h19.IsChecked = false;
            h20.IsChecked = false;
            h21.IsChecked = false;
            h22.IsChecked = false;
            h23.IsChecked = false;
            h24.IsChecked = false;
            initialTb.Text = "";
            
            n = new Hc();
        }

        public void updateM()
        {


        }

        private void htoogle_eventhandler(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ToggleButton t = (ToggleButton)sender;
                string nm = t.Name;
                if ((bool)t.IsChecked)
                {
                    //Hc n = new Hc();
                    switch (nm)
                    {
                        case "h1":
                            n.H1 = "1";
                            n.Tc += 1;
                            break;
                        case "h2":
                            n.H2 = "2";
                            n.Tc += 1;
                            break;
                        case "h3":
                            n.H3 = "3";
                            n.Tc += 1;
                            break;
                        case "h4":
                            n.H4 = "4";
                            n.Tc += 1;
                            break;
                        case "h5":
                            n.H5 = "5";
                            n.Tc += 1;
                            break;
                        case "h6":
                            n.H6 = "6";
                            n.Tc += 1;
                            break;
                        case "h7":
                            n.H7 = "7";
                            n.Tc += 1;
                            break;
                        case "h8":
                            n.H8 = "8";
                            n.Tc += 1;
                            break;
                        case "h9":
                            n.H9 = "9";
                            n.Tc += 1;
                            break;
                        case "h10":
                            n.H10 = "10";
                            n.Tc += 1;
                            break;
                        case "h11":
                            n.H11 = "11";
                            n.Tc += 1;
                            break;
                        case "h12":
                            n.H12 = "12";
                            n.Tc += 1;
                            break;
                        case "h13":
                            n.H13 = "13";
                            n.Tc += 1;
                            break;
                        case "h14":
                            n.H14 = "14";
                            n.Tc += 1;
                            break;
                        case "h15":
                            n.H15 = "15";
                            n.Tc += 1;
                            break;
                        case "h16":
                            n.H16 = "16";
                            n.Tc += 1;
                            break;
                        case "h17":
                            n.H17 = "17";
                            n.Tc += 1;
                            break;
                        case "h18":
                            n.H18 = "18";
                            n.Tc += 1;
                            break;
                        case "h19":
                            n.H19 = "19";
                            n.Tc += 1;
                            break;
                        case "h20":
                            n.H20 = "20";
                            n.Tc += 1;
                            break;
                        case "h21":
                            n.H21 = "21";
                            n.Tc += 1;
                            break;
                        case "h22":
                            n.H22 = "22";
                            n.Tc += 1;
                            break;
                        case "h23":
                            n.H23 = "23";
                            n.Tc += 1;
                            break;
                        case "h24":
                            n.H24 = "24";
                            n.Tc += 1;
                            break;

                    }
                   // MessageBox.Show(n.Tc.ToString());
                }
                else
                {
                    switch (nm)
                    {
                        case "h1":
                            n.H1 = "";
                            n.Tc -= 1;
                            break;
                        case "h2":
                            n.H2 = "";
                            n.Tc -= 1;
                            break;
                        case "h3":
                            n.H3 = "";
                            n.Tc -= 1;
                            break;
                        case "h4":
                            n.H4 = "";
                            n.Tc -= 1;
                            break;
                        case "h5":
                            n.H5 = "";
                            n.Tc -= 1;
                            break;
                        case "h6":
                            n.H6 = "";
                            n.Tc -= 1;
                            break;
                        case "h7":
                            n.H7 = "";
                            n.Tc -= 1;
                            break;
                        case "h8":
                            n.H8 = "";
                            n.Tc -= 1;
                            break;
                        case "h9":
                            n.H9 = "";
                            n.Tc -= 1;
                            break;
                        case "h10":
                            n.H10 = "";
                            n.Tc -= 1;
                            break;
                        case "h11":
                            n.H11 = "";
                            n.Tc -= 1;
                            break;
                        case "h12":
                            n.H12 = "";
                            n.Tc -= 1;
                            break;
                        case "h13":
                            n.H13 = "";
                            n.Tc -= 1;
                            break;
                        case "h14":
                            n.H14 = "";
                            n.Tc -= 1;
                            break;
                        case "h15":
                            n.H15 = "";
                            n.Tc -= 1;
                            break;
                        case "h16":
                            n.H16 = "";
                            n.Tc -= 1;
                            break;
                        case "h17":
                            n.H17 = "";
                            n.Tc -= 1;
                            break;
                        case "h18":
                            n.H18 = "";
                            n.Tc -= 1;
                            break;
                        case "h19":
                            n.H19 = "";
                            n.Tc -= 1;
                            break;
                        case "h20":
                            n.H20 = "";
                            n.Tc -= 1;
                            break;
                        case "h21":
                            n.H21 = "";
                            n.Tc -= 1;
                            break;
                        case "h22":
                            n.H22 = "";
                            n.Tc -= 1;
                            break;
                        case "h23":
                            n.H23 = "";
                            n.Tc -= 1;
                            break;
                        case "h24":
                            n.H24 = "";
                            n.Tc -= 1;
                            break;

                    }
                }
                

                //MessageBox.Show(t.IsChecked.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void hclist_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(((Hc)hclist.SelectedItem).Dt.ToShortDateString());
            
            ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

       

        private void MenuItem_ClickDelete(object sender, RoutedEventArgs e)
        {
            //dList.RemoveAt(hclist.SelectedIndex);
            DataRowView myh = (DataRowView)hclist.SelectedItem;
            dbms mydb = new dbms("HCdb.sqlite");
            mydb.connect(@"HCdb.sqlite");
            mydb.deleteDt(myh[0].ToString());
            mydb.close();

            try
            {
                string sql = "select * from hourlycheck;";
                mydb.connect("HCdb.sqlite");
                ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, mydb.dbConnection);
                da.Fill(ds);
                hclist.ItemsSource = ds.Tables[0].DefaultView;
                mydb.close();
            }
            catch (Exception mye)
            {
                MessageBox.Show(mye.Message);
            }

            
        }

        private void MenuItem_ClickEdit(object sender, RoutedEventArgs e)
        {
            DataRowView myh=(DataRowView)hclist.SelectedItem;
            n = new Hc();
           //MessageBox.Show(dList[hclist.SelectedIndex].Id.ToString());
            dt.Text=myh[0].ToString();
            cDate = myh[0].ToString();
            
            initialTb.Text = myh[25].ToString();

            h1.IsChecked = string.IsNullOrEmpty(myh[1].ToString()) ? false : true;
            n.H1 = myh[1].ToString();
            h2.IsChecked = string.IsNullOrEmpty(myh[2].ToString()) ? false : true;
            n.H2 = myh[2].ToString();
            h3.IsChecked = string.IsNullOrEmpty(myh[3].ToString()) ? false : true;
            n.H3 = myh[3].ToString();
            h4.IsChecked = string.IsNullOrEmpty(myh[4].ToString()) ? false : true;
            n.H4 = myh[4].ToString();
            h5.IsChecked = string.IsNullOrEmpty(myh[5].ToString()) ? false : true;
            n.H5 = myh[5].ToString();
            h6.IsChecked = string.IsNullOrEmpty(myh[6].ToString()) ? false : true;
            n.H6 = myh[6].ToString();
            h7.IsChecked = string.IsNullOrEmpty(myh[7].ToString()) ? false : true;
            n.H7 = myh[7].ToString();
            h8.IsChecked = string.IsNullOrEmpty(myh[8].ToString()) ? false : true;
            n.H8 = myh[8].ToString();
            h9.IsChecked = string.IsNullOrEmpty(myh[9].ToString()) ? false : true;
            n.H9 = myh[9].ToString();
            h10.IsChecked = string.IsNullOrEmpty(myh[10].ToString()) ? false : true;
            n.H10 = myh[10].ToString();
            h11.IsChecked = string.IsNullOrEmpty(myh[11].ToString()) ? false : true;
            n.H11 = myh[11].ToString();
            h12.IsChecked = string.IsNullOrEmpty(myh[12].ToString()) ? false : true;
            n.H12 = myh[12].ToString();
            h13.IsChecked = string.IsNullOrEmpty(myh[13].ToString()) ? false : true;
            n.H13 = myh[13].ToString();
            h14.IsChecked = string.IsNullOrEmpty(myh[14].ToString()) ? false : true;
            n.H14 = myh[14].ToString();
            h15.IsChecked = string.IsNullOrEmpty(myh[15].ToString()) ? false : true;
            n.H15 = myh[15].ToString();
            h16.IsChecked = string.IsNullOrEmpty(myh[16].ToString()) ? false : true;
            n.H16 = myh[16].ToString();
            h17.IsChecked = string.IsNullOrEmpty(myh[17].ToString()) ? false : true;
            n.H17 = myh[17].ToString();
            h18.IsChecked = string.IsNullOrEmpty(myh[18].ToString()) ? false : true;
            n.H18 = myh[18].ToString();
            h19.IsChecked = string.IsNullOrEmpty(myh[19].ToString()) ? false : true;
            n.H19 = myh[19].ToString();
            h20.IsChecked = string.IsNullOrEmpty(myh[20].ToString()) ? false : true;
            n.H20 = myh[20].ToString();
            h21.IsChecked = string.IsNullOrEmpty(myh[21].ToString()) ? false : true;
            n.H21 = myh[21].ToString();
            h22.IsChecked = string.IsNullOrEmpty(myh[22].ToString()) ? false : true;
            n.H22 = myh[22].ToString();
            h23.IsChecked = string.IsNullOrEmpty(myh[23].ToString()) ? false : true;
            n.H23 = myh[23].ToString();
            h24.IsChecked = string.IsNullOrEmpty(myh[24].ToString()) ? false : true;
            n.H24 = myh[24].ToString();

            no = Int32.Parse(myh[26].ToString());
            n.Tc = Int32.Parse(myh[26].ToString());
            
            tbentry.IsSelected = true;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dbms mydb = new dbms("HCdb.sqlite");
            try
            {
                string sql = "select * from hourlycheck;";
                mydb.connect("HCdb.sqlite");
                
                var da = new SQLiteDataAdapter(sql, mydb.dbConnection);
                da.Fill(ds);
                hclist.ItemsSource = ds.Tables[0].DefaultView;
                mydb.close();
            }
            catch (Exception mye)
            {
                MessageBox.Show(mye.Message);
            }
        }
    }
}
