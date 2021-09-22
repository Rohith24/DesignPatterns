using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTracking
{
    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get; }

    }

    public class LightTheme : ITheme
    {
        public string BgrColor => "White";
        public string TextColor => "Black";
    }


    public class DarkTheme : ITheme
    {
        public string BgrColor => "dark gray";
        public string TextColor => "white";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> _themes = new List<WeakReference<ITheme>>();

        public ITheme CreateTheme(bool dark)
        {
            ITheme theme;
            if (dark)
                theme = new DarkTheme();
            else
                theme = new LightTheme();

            _themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var refernce in _themes)
                {
                    if (refernce.TryGetTarget(out var theme))
                    {
                        bool dark = theme is DarkTheme;
                        sb.Append(dark ? "Dark" : "Light").AppendLine(" theme");
                    }
                }
                return sb.ToString();
            }
        }
    }

    public class ReplacebaleThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> _themes = new List<WeakReference<Ref<ITheme>>>();

        private ITheme createThemeImpl(bool dark)
        {
            if (dark)
                return new DarkTheme();
            else
                return new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(createThemeImpl(dark));
            _themes.Add(new WeakReference<Ref<ITheme>>(r));
            return r;
        }

        public void ReplaceTheme(bool dark)
        {
            foreach (var wr in _themes)
            {
                if (wr.TryGetTarget(out var refernce))
                {
                    refernce.Value = createThemeImpl(dark);
                }
            }
        }
    }

    public class Ref<T> where T : class
    {
        public T Value;
        public Ref(T value)
        {
            Value = value;
        }
    }

    public class FactoryPr
    {
        public void main()
        {

            var trackingTheme = new TrackingThemeFactory();
            var dark = trackingTheme.CreateTheme(true);
            var light = trackingTheme.CreateTheme(false);
            Console.WriteLine(trackingTheme.Info);


            var magicFactory = new ReplacebaleThemeFactory();
            var theme = magicFactory.CreateTheme(true);
            Console.WriteLine(theme.Value.BgrColor);
            magicFactory.ReplaceTheme(false);
            Console.WriteLine(theme.Value.BgrColor);



        }
    }

}
