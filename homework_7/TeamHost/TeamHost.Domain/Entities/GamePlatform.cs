using System.ComponentModel.DataAnnotations;

namespace TeamHost.Domain.Entities;

public class GamePlatform
{
    /// Id игры
    [Required]
    public uint GameId { get; set; }
     
    /// Id категории
    [Required]
    public uint PlatformId { get; set; }
        
    /// <summary>
    /// Навигационное свойство для связи с игрой
    /// </summary>
    public Game Game { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с категорией
    /// </summary>
    public Platform Platform { get; set; }
    
    public List<GamePlatform> GamePlatforms { get; set; }
}