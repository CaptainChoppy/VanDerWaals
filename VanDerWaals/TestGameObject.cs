namespace VanDerWaals
{
    internal class TestGameObject : GameObject
    {
        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            float angle = Time.GlobalFrameTime * Time.DeltaTime * 2.0f;

            Position = new WorldPosition(Maths.Cosine(angle) * 100.0f, Maths.Sine(angle) * 100.0f);
        }
    }
}
