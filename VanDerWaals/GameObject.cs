using System.Numerics;

namespace VanDerWaals
{
    internal abstract class GameObject
    {
        public WorldPosition Position = WorldPosition.Zero;
        public Vector2 Size = Textures.Test.Size;

        public GameObject()
        {
            ObjectRegistry.AddObject(this);
        }

        public void Destroy()
        {
            ObjectRegistry.RemoveObject(this);
        }

        public virtual void Start() { }
        public virtual void Update() { }

        public virtual void Draw() { }
    }
}
