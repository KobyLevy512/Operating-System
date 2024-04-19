
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using GamingOS.Resources;
using System;
using System.Drawing;

namespace GamingOS.Styles
{
    public class Style
    {
        public enum StyleType : byte
        {
            Dark = 2,
            Blue = 4,
            Purple = 8,
            Cyan = 16,
            Green = 32,
            Yellow = 64
        }

        public Pen Primary, PrimaryLight, PrimaryDark;
        public Pen Secondry, SecondryLight, SecondryDark;
        public Pen Background, Foreground;
        public Font Font;
        private Pen ColorFromHex(uint value)
        {
            return new Pen(Color.FromArgb((int)((value >> 24) & 255), (int)((value >> 16) & 255), (int)((value >> 8) & 255), (int)(value & 255)));
        }

        private Pen AddBright(Color src, float light)
        {
            return new Pen(Color.FromArgb(src.A, (int)(src.R * light), (int)(src.G * light), (int)(src.B * light)));
        }
        public Style(StyleType type)
        {
            byte t = (byte)type;
            Font = PCScreenFont.Default;
            //Blue
            if ((t & 4) != 0)
            {
                Background = ColorFromHex(0xFFDEE9FC);
                Foreground = ColorFromHex(0xFF0F1A2E);

                Primary = ColorFromHex(0xFF2F63C3);
                PrimaryDark = ColorFromHex(0xFF1B386F);
                PrimaryLight = ColorFromHex(0xFF789BDE);

                Secondry = ColorFromHex(0xFFD98729);
                SecondryDark = ColorFromHex(0xFF865318);
                SecondryLight = ColorFromHex(0xFFE9B981);

            }
            //Purple
            else if ((t & 8) != 0)
            {
                Background = ColorFromHex(0xFFEDE7F8);
                Foreground = ColorFromHex(0xFF1B0F2E);

                Primary = ColorFromHex(0xFF6031B2);
                PrimaryDark = ColorFromHex(0xFF361B64);
                PrimaryLight = ColorFromHex(0xFF9873D9);

                Secondry = ColorFromHex(0xFFDEC742);
                SecondryDark = ColorFromHex(0xFF9C891C);
                SecondryLight = ColorFromHex(0xFFEDE097);
            }
            //Cyan
            else if ((t & 16) != 0)
            {
                Background = ColorFromHex(0xFFE3FEF7);
                Foreground = ColorFromHex(0xFF003C43);

                Primary = ColorFromHex(0xFF77B0AA);
                PrimaryDark = ColorFromHex(0xFF135D66);
                PrimaryLight = AddBright(Primary.Color, 1.2f);

                Secondry = ColorFromHex(0xFFBF3131);
                SecondryDark = ColorFromHex(0xFF7D0A0A);
                SecondryLight = AddBright(Secondry.Color, 1.2f);
            }
            //Green
            else if ((t & 32) != 0)
            {
                Background = ColorFromHex(0xFFEEF6E9);
                Foreground = ColorFromHex(0xFF1C2E0F);

                Primary = ColorFromHex(0xFF6A9F44);
                PrimaryDark = ColorFromHex(0xFF3C5926);
                PrimaryLight = ColorFromHex(0xFFA0C982);

                Secondry = ColorFromHex(0xFFDD4234);
                SecondryDark = ColorFromHex(0xFF942319);
                SecondryLight = ColorFromHex(0xFFEC958E);
            }
            //Yellow
            else if ((t & 64) != 0)
            {
                Background = ColorFromHex(0xFFFBFBE5);
                Foreground = ColorFromHex(0xFF2E2E0F);

                Primary = ColorFromHex(0xFFE2E253);
                PrimaryDark = ColorFromHex(0xFFB3B31E);
                PrimaryLight = ColorFromHex(0xFFF1F1AC);

                Secondry = ColorFromHex(0xFF7C1A9A);
                SecondryDark = ColorFromHex(0xFF350B41);
                SecondryLight = ColorFromHex(0xFFB83BDE);
            }
            else
            {
                throw new ArgumentOutOfRangeException("type", "Type must have 1 Foreground color");
            }

            //Check if is this dark mode
            if((t & 2) != 0)
            {
                Pen tmp = Foreground;
                Foreground = Background;
                Background = tmp;
            }
        }
    }
}
