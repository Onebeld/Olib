using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace Olib.Core
{
    class Animations
    {
        /// <summary>
        /// Активирует анимацию для текста
        /// </summary>
        /// <param name="control">Элемент, для которого нужно активировать анимацию, в данном случае DropShadow</param>
        public static void AnimationText(DropShadowEffect control)
        {
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                To = 10,
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };
            control.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
        }
        /// <summary>
        /// Активирует анимацию для текста
        /// </summary>
        /// <param name="control">Элемент, для которого нужно активировать анимацию</param>
        /// <param name="control1">Второй элемент, для которого нужно активировать анимацию/param>
        public static void AnimationText(DropShadowEffect control, DropShadowEffect control1)
        {
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                To = 10,
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };
            control.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
            control1.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
        }
    }
}
