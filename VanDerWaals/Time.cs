using System;
namespace VanDerWaals
{
    internal static class Time
    {
        public static float DeltaTime => 1.0f / Renderer.FrameRate;
        public static uint GlobalFrameTime { get; private set; } = 0;

        public static void Update()
        {
            GlobalFrameTime++;
        }
    }
}
