using System.Numerics;

namespace VanDerWaals
{
    internal abstract class GameObject
    {
        public WorldPosition Position = WorldPosition.Zero;
        public Vector2 Size = Textures.Default.Size;

        public Texture Texture { get; private set; } = Textures.Default;

        public GameObject()
        {
            ObjectRegistry.AddObject(this);
        }

        public void Destroy()
        {
            ObjectRegistry.RemoveObject(this);
        }

        public virtual void Start() { return; }
        public virtual void Update() { return; }
        public virtual void OnDestroy() { return; } 

        public virtual void Draw()
        {
            Renderer.DrawGameObject(this);
        }

        public virtual void OnClick() { return; }
    }
}
