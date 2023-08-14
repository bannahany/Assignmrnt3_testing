﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignement_3_Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {          
                string product_name = txt_product_Name.Text;
                int product_id = int.Parse(txt_Product_Id.Text);
                int amount_kg = int.Parse(txt_Amount_kg.Text);
                double price_cad_kg = double.Parse(txt_Price.Text);

                databaseOperations.AddData(product_name, product_id, amount_kg, price_cad_kg);
           
        }

    }
}

