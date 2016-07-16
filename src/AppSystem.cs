using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    public static class AppSystem
    {
        private static Block _currentBlock;
        private static Timer _timer;
        
        public static uint DeltaTime
        {
            get { return _timer.Ticks - LastFrameTime; }
        }

        public static uint LastFrameTime { get; private set; }

        public static uint TotalTime
        {
            get { return _timer.Ticks; }
        }

        static AppSystem()
        {
            SwinGame.OpenGraphicsWindow(AppConfig.AppFullName(), AppConfig.ScreenWidth, AppConfig.ScreenHeight);
            
            _timer = SwinGame.CreateTimer();
            LastFrameTime = 0u;

            _currentBlock = CreateBlock();
        }

        private static Block CreateBlock()
        {
            Random rng = new Random();
            int width = 36;
            Point2D start = SwinGame.PointAt(AppConfig.ScreenWidth / 2f - 2f * width, 0);
            Block newBlock;

            switch (rng.Next(7))
            {
                case 1:
                    newBlock = new BlockJ(start.Add(SwinGame.VectorTo(0, -3f * width)), width);
                    break;
                case 2:
                    newBlock = new BlockL(start.Add(SwinGame.VectorTo(0, -3f * width)), width);
                    break;
                case 3:
                    newBlock = new BlockO(start.Add(SwinGame.VectorTo(0, -3f * width)), width);
                    break;
                case 4:
                    newBlock = new BlockS(start.Add(SwinGame.VectorTo(0, -2f * width)), width);
                    break;
                case 5:
                    newBlock = new BlockT(start.Add(SwinGame.VectorTo(0, -2f * width)), width);
                    break;
                case 6:
                    newBlock = new BlockZ(start.Add(SwinGame.VectorTo(0, -2f * width)), width);
                    break;
                default: // case 0
                    newBlock = new BlockI(start.Add(SwinGame.VectorTo(0, -4f * width)), width);
                    break;
            }
            newBlock.Construct();
            return newBlock;
        }

        private static void Render()
        {
            SwinGame.ClearScreen(AppConfig.Background);
            _currentBlock.Render();
            SwinGame.RefreshScreen(AppConfig.LimitFps);
        }

        public static void Run()
        {
            _timer.Start();

            do
            {
                SwinGame.ProcessEvents();
                if (SwinGame.KeyTyped(KeyCode.vk_q)) _currentBlock.Rotate(-90);
                if (SwinGame.KeyTyped(KeyCode.vk_e)) _currentBlock.Rotate(90);
                if (SwinGame.KeyTyped(KeyCode.vk_p)) Console.WriteLine("(T,R,B,L) = ({0},{1},{2},{3})",
                    _currentBlock.Top,
                    _currentBlock.Right,
                    _currentBlock.Bottom,
                    _currentBlock.Left);
                if (SwinGame.KeyTyped(KeyCode.vk_c)) _currentBlock = CreateBlock();
                if (SwinGame.KeyDown(KeyCode.vk_DOWN)) _currentBlock.Drop();
                Update();
                Render();
            } while (!SwinGame.WindowCloseRequested());
        }

        public static void Terminate()
        {
            _timer.Stop();
            _timer.Dispose();
            SwinGame.ReleaseAllResources();
        }

        private static void Update()
        {
            _currentBlock.Fall();
            LastFrameTime = _timer.Ticks;
        }
    }
}
