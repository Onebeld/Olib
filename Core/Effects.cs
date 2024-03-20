using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Olib
{
    class InvertEffect : ShaderEffect
    {
        private const string V =
@"AAP///7/HwBDVEFCHAAAAE8AAAAAA///AQAAABwAAAAAAQAASAAAADAAAAADAAAAAQACADgAAAAA
AAAAaW5wdXQAq6sEAAwAAQABAAEAAAAAAAAAcHNfM18wAE1pY3Jvc29mdCAoUikgSExTTCBTaGFk
ZXIgQ29tcGlsZXIgMTAuMQCrUQAABQAAD6AAAIA/AAAAAAAAAAAAAAAAHwAAAgUAAIAAAAOQHwAA
AgAAAJAACA+gQgAAAwAAD4AAAOSQAAjkoAIAAAMAAAeAAADkgQAAAKAFAAADAAgHgAAA/4AAAOSA
AQAAAgAICIAAAP+A//8AAA==";

        private static readonly PixelShader _shader;

        static InvertEffect()
        {
            _shader = new PixelShader();
            _shader.SetStreamSource(new MemoryStream(Convert.FromBase64String(V)));
        }

        public InvertEffect()
        {
            PixelShader = _shader;
            UpdateShaderValue(InputProperty);
        }

        public Brush Input
        {
            get => (Brush)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public static readonly DependencyProperty InputProperty =
            RegisterPixelShaderSamplerProperty("Input", typeof(InvertEffect), 0);

    }
}
