using System.ComponentModel;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using System;

namespace SexyPurpleTooltips;

public class Config : ModConfig
{
    public static Config Instance { get; private set; }

    public override void OnLoaded()
    {
        Instance = this;
    }

    public override ConfigScope Mode => ConfigScope.ServerSide;

    [DefaultValue(0)]
    [Range(0, 360)]
    public int Hue;
}

public class Tooltips : GlobalItem
{
    private static readonly Dictionary<string, Color> baseColors = new()
    {
        { "default", new Color(255, 153, 255) },
        { "first", new Color(255, 77, 255) },
        { "damage", new Color(179, 0, 179) },
        { "critical", new Color(255, 0, 191) },
        { "speed", new Color(204, 51, 255) },
        { "knockback", new Color(255, 77, 148) },
        { "power", new Color(153, 51, 255) },
        { "life", new Color(255, 51, 153) },
        { "consumable", new Color(255, 153, 204) },
        { "material", new Color(255, 153, 190) },
        { "placed", new Color(255, 153, 180) }
    };

    private static Color AdjustHue(Color color, int hueShift)
    {
        Vector3 hsv = color.ToVector3().ToHSV();
        hsv.X = (hsv.X + hueShift / 360f) % 1f; // Shift hue and wrap around
        return hsv.ToColor();
    }

    private static void SetColor(TooltipLine line, string type)
    {
        if (line.Text.Contains(type))
        {
            line.OverrideColor = AdjustHue(baseColors[type], Config.Instance.Hue);
        }
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        for (int i = 0; i < tooltips.Count; i++)
        {
            var line = tooltips[i];

            line.OverrideColor = AdjustHue(baseColors["default"], Config.Instance.Hue);

            if (i == 0)
            {
                line.OverrideColor = AdjustHue(baseColors["first"], Config.Instance.Hue);
            }

            SetColor(line, "damage");
            SetColor(line, "critical");
            SetColor(line, "speed");
            SetColor(line, "knockback");
            SetColor(line, "power");
            SetColor(line, "life");
            SetColor(line, "consumable");
            SetColor(line, "material");
            SetColor(line, "placed");

            if (line.IsModifier)
            {
                line.OverrideColor = AdjustHue(new Color(204, 51, 255), Config.Instance.Hue);
            }
        }
    }
}

public static class ColorExtensions
{
    public static Vector3 ToHSV(this Vector3 rgb)
    {
        float max = Math.Max(rgb.X, Math.Max(rgb.Y, rgb.Z));
        float min = Math.Min(rgb.X, Math.Min(rgb.Y, rgb.Z));
        float delta = max - min;

        float hue = 0f;
        if (delta > 0)
        {
            if (max == rgb.X)
            {
                hue = (rgb.Y - rgb.Z) / delta + (rgb.Y < rgb.Z ? 6 : 0);
            }
            else if (max == rgb.Y)
            {
                hue = (rgb.Z - rgb.X) / delta + 2;
            }
            else if (max == rgb.Z)
            {
                hue = (rgb.X - rgb.Y) / delta + 4;
            }

            hue /= 6f;
        }

        float saturation = max == 0 ? 0 : delta / max;
        float value = max;

        return new Vector3(hue, saturation, value);
    }

    public static Color ToColor(this Vector3 hsv)
    {
        float h = hsv.X * 6f;
        float s = hsv.Y;
        float v = hsv.Z;

        int i = (int)Math.Floor(h) % 6;
        float f = h - i;
        float p = v * (1 - s);
        float q = v * (1 - f * s);
        float t = v * (1 - (1 - f) * s);

        return i switch
        {
            0 => new Color(v, t, p),
            1 => new Color(q, v, p),
            2 => new Color(p, v, t),
            3 => new Color(p, q, v),
            4 => new Color(t, p, v),
            5 => new Color(v, p, q),
            _ => new Color(v, p, p),
        };
    }
}
