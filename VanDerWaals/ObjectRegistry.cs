namespace VanDerWaals
{
    internal static class ObjectRegistry
    {
        private static List<GameObject> GameObjects = new List<GameObject>();

        public static void Update()
        {
            foreach (GameObject gameobject in GameObjects)
            {
                gameobject.Update();
            }
        }

        public static void DrawObjects()
        {
            foreach (GameObject gameobject in GameObjects)
            {
                gameobject.Draw();
            }
        }

        public static void AddObject(GameObject gameobject)
        {
            GameObjects.Add(gameobject);
            gameobject.Start();
        }

        public static void RemoveObject(GameObject gameobject)
        {
            GameObjects.Remove(gameobject);
        }
    }
}
