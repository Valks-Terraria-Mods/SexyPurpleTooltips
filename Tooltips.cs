using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SexyPurpleTooltips {
    public class Tooltips : GlobalItem {

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            for (int i = 0; i < tooltips.Count; i++) {
                TooltipLine line = tooltips[i];

                line.overrideColor = new Color(255, 153, 255); // default color

                if (i == 0) {
                    line.overrideColor = new Color(255, 77, 255);
                }

                if (line.text.Contains("damage")) {
                    line.overrideColor = new Color(179, 0, 179);
                }

                if (line.text.Contains("critical")) {
                    line.overrideColor = new Color(255, 0, 191);
                }

                if (line.text.Contains("speed")) {
                    line.overrideColor = new Color(204, 51, 255);
                }

                if (line.text.Contains("knockback")) {
                    line.overrideColor = new Color(255, 77, 148);
                }

                if (line.text.Contains("power")) {
                    line.overrideColor = new Color(153, 51, 255);
                }

                if (line.text.Contains("life")) {
                    line.overrideColor = new Color(255, 51, 153);
                }

                if (line.text.Contains("consumable")) {
                    line.overrideColor = new Color(255, 153, 204);
                }

                if (line.text.Contains("material")) {
                    line.overrideColor = new Color(255, 153, 190);
                }

                if (line.text.Contains("placed")) {
                    line.overrideColor = new Color(255, 153, 180);
                }

                if (line.isModifier) {
                    line.overrideColor = new Color(204, 51, 255);
                }

            }
        }

    }
}
