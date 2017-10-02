﻿using System.Windows;
using System.Windows.Media;
using Infrastructure;
using Jot.DefaultInitializer;
using Prism.Mvvm;

namespace ServicesModule.Services
{
    public class Settings : BindableBase, ISettings
    {
        private FontFamily _font = new FontFamily("Consolas");
        private double _fontSize = 16;
        private bool _wordWrap = true;
        private string _currentFileName = string.Empty;

        public Settings()
        {
            Globals.Tracker.Configure(this).Apply();
            Application.Current.MainWindow.Closed += (sd, ea) => Globals.Tracker.Configure(this).Persist();
        }

        [Trackable]
        public string CurrentFileName
        {
            get => _currentFileName;
            set => SetProperty(ref _currentFileName, value);
        }

        [Trackable]
        public FontFamily Font
        {
            get => _font;
            set => SetProperty(ref _font, value);
        }

        [Trackable]
        public double FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize,  value);
        }

        [Trackable]
        public bool WordWrap
        {
            get => _wordWrap;
            set => SetProperty(ref _wordWrap, value);
        }
    }
}