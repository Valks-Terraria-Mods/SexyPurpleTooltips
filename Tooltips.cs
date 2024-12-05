using System.ComponentModel;
using Terraria.ModLoader.Config;

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
    public int Hue;
}

public class Tooltips : GlobalItem
{
    private static readonly Dictionary<string, Color> colors = new()
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

    private static void SetColor(TooltipLine line, string type) 
    {
        if (line.Text.Contains(type))
        {
            line.OverrideColor = colors[type];
        }
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        for (int i = 0; i < tooltips.Count; i++)
        {
            var line = tooltips[i];

            line.OverrideColor = colors["default"];

            if (i == 0)
            {
                line.OverrideColor = colors["first"];
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
                line.OverrideColor = new Color(204, 51, 255);
            }
        }
    }
}
