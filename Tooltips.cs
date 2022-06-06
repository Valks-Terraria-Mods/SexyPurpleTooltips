namespace SexyPurpleTooltips;

public class Tooltips : GlobalItem
{
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        for (int i = 0; i < tooltips.Count; i++)
        {
            TooltipLine line = tooltips[i];

            line.OverrideColor = new Color(255, 153, 255); // default color

            if (i == 0)
            {
                line.OverrideColor = new Color(255, 77, 255);
            }

            if (line.Text.Contains("damage"))
            {
                line.OverrideColor = new Color(179, 0, 179);
            }

            if (line.Text.Contains("critical"))
            {
                line.OverrideColor = new Color(255, 0, 191);
            }

            if (line.Text.Contains("speed"))
            {
                line.OverrideColor = new Color(204, 51, 255);
            }

            if (line.Text.Contains("knockback"))
            {
                line.OverrideColor = new Color(255, 77, 148);
            }

            if (line.Text.Contains("power"))
            {
                line.OverrideColor = new Color(153, 51, 255);
            }

            if (line.Text.Contains("life"))
            {
                line.OverrideColor = new Color(255, 51, 153);
            }

            if (line.Text.Contains("consumable"))
            {
                line.OverrideColor = new Color(255, 153, 204);
            }

            if (line.Text.Contains("material"))
            {
                line.OverrideColor = new Color(255, 153, 190);
            }

            if (line.Text.Contains("placed"))
            {
                line.OverrideColor = new Color(255, 153, 180);
            }

            if (line.IsModifier)
            {
                line.OverrideColor = new Color(204, 51, 255);
            }

        }
    }
}
