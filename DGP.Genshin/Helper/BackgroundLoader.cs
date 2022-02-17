﻿using DGP.Genshin.Service.Abstratcion;
using Snap.Extenion.Enumerable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DGP.Genshin.Helper
{
    internal class BackgroundLoader
    {
        private const string BackgroundFolder = "Background";
        private readonly IEnumerable<string> supportedExtensions = new List<string>() { ".png", ".jpg", ".bmp" };

        private readonly MainWindow mainWindow;
        private readonly ISettingService settingService;

        public BackgroundLoader(MainWindow mainWindow, ISettingService settingService)
        {
            this.mainWindow = mainWindow;
            this.settingService = settingService;
        }

        public void LoadWallpaper()
        {
            string folder = PathContext.Locate(BackgroundFolder);
            Directory.CreateDirectory(folder);
            IEnumerable<string> paths = Directory.EnumerateFiles(folder);
            List<string> supportedFiles = paths
                .Where(path => supportedExtensions.Contains(Path.GetExtension(path)))
                .ToList();

            if (supportedFiles.GetRandom() is string randomPath)
            {
                mainWindow.BackgroundGrid.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new(randomPath)),
                    Stretch = Stretch.UniformToFill,
                    Opacity = settingService.GetOrDefault(Setting.BackgroundOpacity, 0.4)
                };
            }
        }
    }
}
