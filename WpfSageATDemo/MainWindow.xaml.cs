﻿using ConsoleApp2;
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

namespace WpfSageATDemo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoggingService logger = new LoggingService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //über sender.getType().Name kann man den Typ holen
            //über sender as Button wird die Abfrage im Complier durchgeführt - wenn es ein Button ist wird Button übergeben ansonsten null
         
            try
            {

                if (sender is Control button)
                {
                    //button.Background = Brushes.Red;
                    //e.Handled = true;
                    var tag = (string)button.Tag;
                    
                    switch (tag)
                    {
                        case "Log":
                            logger.Log("Blue Button was clicked ");
                            break;
                        case "Delete Temp Log":
                            logger.Logdelete();
                            break;
                        default:
                            break;
                    }
                    //var color = s?.Background - über ? wird abgefragt ob was dahinter ist.
                }

            }
            catch (InvalidCastException ice)
            {

                logger.Log(ice.Message);
            }
        }
    }
}
