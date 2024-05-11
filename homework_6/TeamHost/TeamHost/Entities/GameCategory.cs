using System.ComponentModel.DataAnnotations;

namespace TeamHost.Entities;

/// <summary>
/// Промежуточная сущность, представляющая таблицу, связывающую игры и категории
/// </summary>
public class GameCategory
{
    /// Id игры
    [Required]
    public uint GameId { get; set; }
     
    /// Id категории
    [Required]
    public uint CategoryId { get; set; }
        
    /// <summary>
    /// Навигационное свойство для связи с игрой
    /// </summary>
    public Game Game { get; set; }
    /// <summary>
    /// Навигационное свойство для связи с категорией
    /// </summary>
    public Category Category { get; set; }
}