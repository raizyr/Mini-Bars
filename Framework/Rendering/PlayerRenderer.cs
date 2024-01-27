using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ImprovedMiniBars.Framework.Rendering
{
    public class PlayerRenderer
    {
        //private static int _verification_range = 100 * Game1.pixelZoom;

        public static void OnRendered(object sender, RenderedWorldEventArgs e)
        {
            if (!Context.IsWorldReady) return;
            if (!ModEntry.config.Show_Player_Bar) return;
            if (!Game1.showingHealth && !ModEntry.config.Show_Full_Life) return;

            Farmer _player = Game1.player;
            float _current_health = _player.health;
            float _current_max_health = Math.Max(_player.health, _player.maxHealth);
            if (!ModEntry.config.Show_Full_Life && _current_health >= _current_max_health) return;

            BarInformation _information = Textures.barInformation.Find(x => x.entityType == _player.GetType().Name) ??
                Textures.barInformation.Find(x => x.entityType == "Farmer");

            Texture2D _current_sprite = _information.texture;
            Color _bar_color = _information.barColor;
            Color _border_color = _information.borderColor;
            Color _hp_color = _information.hpColor;
            int _height = _information.height;
            Vector2 _playerPos = _player.getLocalPosition(Game1.viewport);

            if (_player.currentLocation.Name == "CrimsonBadlands" || _player.currentLocation.Name == "IridiumQuarry")
            {
                _bar_color = new Color(192, 64, 45);
                _border_color = new Color(192, 64, 45);
            }

            const int _height_adjustment = 3;
            const int _width_adjustment = 0;

            Game1.spriteBatch.Draw(
                Textures.Pixel,
                new Rectangle(
            (int)_playerPos.X - Textures.Pixel.Width * Game1.pixelZoom / 2 + _player.FarmerSprite.SpriteWidth * Game1.pixelZoom / 2 - Database.player_distance_x * Game1.pixelZoom - _width_adjustment,
            (int)_playerPos.Y - _player.FarmerSprite.SpriteHeight * Game1.pixelZoom - _height * Game1.pixelZoom + 9 * Game1.pixelZoom - _height_adjustment,
                    (Textures.Pixel.Width * Game1.pixelZoom) * Database.player_bar_size,
                    (Textures.Pixel.Height * Game1.pixelZoom) * 4),
                new Color(0, 0, 0, 135));
           
            Game1.spriteBatch.Draw(
                    Textures.Pixel,
            new Rectangle(
                        (int)_playerPos.X - Textures.Pixel.Width * Game1.pixelZoom / 2 + _player.FarmerSprite.SpriteWidth * Game1.pixelZoom / 2 - Database.player_distance_x * Game1.pixelZoom - _width_adjustment,
                        (int)_playerPos.Y - _player.FarmerSprite.SpriteHeight * Game1.pixelZoom - _height * Game1.pixelZoom + 9 * Game1.pixelZoom - _height_adjustment,
                        (Textures.Pixel.Width * Game1.pixelZoom) * (int)((_current_health / _current_max_health) * Database.player_bar_size),
                        (Textures.Pixel.Height * Game1.pixelZoom) * 4),
                    _bar_color);

            Game1.spriteBatch.Draw(
                _current_sprite,
            new Rectangle(
                    (int)_playerPos.X - _current_sprite.Width * Game1.pixelZoom / 2 + _player.FarmerSprite.SpriteWidth * Game1.pixelZoom / 2,
                    (int)_playerPos.Y - _player.FarmerSprite.SpriteHeight * Game1.pixelZoom - _height * Game1.pixelZoom,
                    _current_sprite.Width * Game1.pixelZoom,
                    _current_sprite.Height * Game1.pixelZoom),
                _border_color);

            if (ModEntry.config.Bars_Theme == 2) return;
            Game1.spriteBatch.Draw(
            Textures.hpSprite,
            new Rectangle(
                (int)_playerPos.X - Textures.hpSprite.Width * Game1.pixelZoom / 2 + _player.FarmerSprite.SpriteWidth * Game1.pixelZoom / 2 + _width_adjustment,
                (int)_playerPos.Y - _player.FarmerSprite.SpriteHeight * Game1.pixelZoom - _height * Game1.pixelZoom + _height_adjustment,
                Textures.hpSprite.Width * Game1.pixelZoom,
                Textures.hpSprite.Height * Game1.pixelZoom),
            _hp_color);
        }
    }
}
