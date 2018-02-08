﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MvxScaffolding.UI.Helpers;
using MvxScaffolding.UI.ViewModels;
using MvxScaffolding.UI.ViewModels.Interfaces;

namespace MvxScaffolding.UI.Views
{
    public partial class MainWindow : MetroWindow, IClosable
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            Brush themeBrush = MvxScaffoldingContext.CurrentTemplateType == TemplateType.MvxNative
                ? (Brush)FindResource("PrimaryColorBrush")
                : (Brush)FindResource("AccentHueColorBrush");

            WindowTitleBrush = themeBrush;
            GlowBrush = themeBrush;
        }

        private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is string stringParameter && !string.IsNullOrWhiteSpace(stringParameter))
            {
                Process.Start(stringParameter);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
