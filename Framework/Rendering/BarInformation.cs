using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ImprovedMiniBars.Framework.Rendering
{
    public class BarInformation
    {
        public string entityName;
        public string entityType;
        public bool editableInGame;
        public Texture2D texture;
        public Color barColor;
        public Color borderColor;
        public Color hpColor;
        public int height;
    }
}
