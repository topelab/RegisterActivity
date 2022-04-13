﻿using RegisterActivity.Main;
using RegisterActivity.Services;
using System;
using System.ComponentModel;
using System.Windows;

namespace RegisterActivity.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private bool isExit;

        private readonly MainWindowVM mainWindowVM;

        public MainWindow(MainWindowVM mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM ?? throw new ArgumentNullException(nameof(mainWindowVM));

            DataContext = this.mainWindowVM;

            InitializeComponent();
            PrepareWindow();
            Hide();
        }

        public MainWindowVM WindowVM => mainWindowVM;

        private void PrepareWindow()
        {
            Closing += MainWindow_Closing;

            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            notifyIcon.Icon = new System.Drawing.Icon(@"Resources/register-activity-70.ico");
            notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            notifyIcon.ContextMenuStrip =
              new System.Windows.Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("MainWindow...").Click += (s, e) => ShowMainWindow();
            notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            isExit = true;
            Close();
            notifyIcon.Dispose();
            notifyIcon = null;
            App.Current.Shutdown();
        }

        private void ShowMainWindow()
        {
            if (IsVisible)
            {
                if (WindowState == WindowState.Minimized)
                {
                    WindowState = WindowState.Normal;
                }
                Activate();
            }
            else
            {
                Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!isExit)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
