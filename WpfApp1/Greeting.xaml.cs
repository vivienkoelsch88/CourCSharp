﻿using ConsoleApp2;
using Microsoft.Toolkit.Wpf.UI.Controls;
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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindowC : Window
    {
        public GreetingViewModel viewModel;
       

        public MainWindowC()
        {
            InitializeComponent();
            this.viewModel = new GreetingViewModel();
            this.DataContext = this.viewModel;
            
            

        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
