using Autofac;
using System;

namespace BridgeDesign
{
    /*
     * If we want to implement drawing a circle in Both Vector and Pixels
     * we need to write different classes like VectorCircle and PixelCircle
     * If we need to draw Rectangle, Triangle again we need to create more class.
     * To Simplify this we can seperate Draw/ Render type as seperate classes and Inject them based on requirement
     * 
     */


    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Circle {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Pixel Circle {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer _render;

        protected Shape(IRenderer render)
        {
            _render = render;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer render, float radius) : base(render)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            _render.RenderCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }


    public class Program
    {
        static void Main1(string[] args)
        {
            var render = new RasterRenderer();
            var circle = new Circle(render, 5);

            circle.Draw();
            circle.Resize(10);
            circle.Draw();

            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();

            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

            using (var c = cb.Build())
            {
                var cir = c.Resolve<Circle>(new PositionalParameter(0, 5.0f));
                cir.Draw();
                cir.Resize(32);
                cir.Draw();
            }
        }
    }
}
