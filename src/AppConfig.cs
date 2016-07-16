using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// Contains the application configuration.
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Indicates the application name.
        /// </summary>
        public const string AppName = "Tetris";

        /// <summary>
        /// Indicates the application version.
        /// </summary>
        public const string AppVersion = "0.1.0";
        
        /// <summary>
        /// Private field which stores background colour data.
        /// </summary>
        private static Lazy<Color> _background;

        /// <summary>
        /// Private field which stores foreground colour data.
        /// </summary>
        private static Lazy<Color> _foreground;

        /// <summary>
        /// Gets or sets the application background colour.
        /// </summary>
        public static Color Background
        {
            get { return _background.Value; }
            set { _background = new Lazy<Color>(() => { return value; }); }
        }

        /// <summary>
        /// Gets or sets the application debug mode.
        /// </summary>
        public static bool Debug { get; set; }

        /// <summary>
        /// Gets or sets the application foreground colour.
        /// </summary>
        public static Color Foreground
        {
            get { return _foreground.Value; }
            set { _foreground = new Lazy<Color>(() => { return value; }); }
        }

        /// <summary>
        /// Gets or sets the maximum frames per second.
        /// </summary>
        public static uint LimitFps { get; set; }

        /// <summary>
        /// Gets or sets the scale ratio between the application and device screen.
        /// </summary>
        public static float ScaleRatio { get; set; }
        
        /// <summary>
        /// Gets or sets the application screen height.
        /// </summary>
        public static int ScreenHeight { get; set; }

        /// <summary>
        /// Gets or sets the application screen width.
        /// </summary>
        public static int ScreenWidth { get; set; }

        /// <summary>
        /// Initialises the <see cref="AppConfig"/> values.
        /// </summary>
        static AppConfig()
        {
            _background = new Lazy<Color>(() => { return SwinGame.RGBColor(240, 240, 240); });
            Debug = true;
            _foreground = new Lazy<Color>(() => { return SwinGame.RGBColor(16, 16, 16); });
            LimitFps = 60u;
            ScaleRatio = 1f;
            ScreenHeight = 720;
            ScreenWidth = 1280;
        }

        /// <summary>
        /// Indicates the application full name, including its current version.
        /// </summary>
        /// <returns>Application name with version.</returns>
        public static string AppFullName()
        {
            return AppName + " v" + AppVersion;
        }
    }
}
