﻿using DBConnection.Data;
using DBConnection.Models;
using GameSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameSearch.Views
{
    /// <summary>
    /// Interaktionslogik für ShellView.xaml
    /// </summary>
    public partial class ShellView : RibbonWindow
    {
        public ShellViewModel ShellViewModel { get; set; }

        public ShellView(ShellViewModel shellViewModel)
        {
            ShellViewModel = shellViewModel;
            InitializeComponent();
        }
    }
}
