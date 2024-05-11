using System.ComponentModel.DataAnnotations;
using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Игра
/// </summary>
public class Game: IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public uint Id { get; set; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена (в вонах)
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Короткое описание
    /// </summary>
    [MaxLength(256)]
    public string ShortDescription { get; set; }

    /// <summary>
    /// Главное изображение
    /// </summary>
    public string StaticFilePath { get; set; }

    /// <summary>
    /// Изображения
    /// </summary>
    public List<StaticFile>? Images { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public float Rating { get; set; }

    /// <summary>
    /// Дата релиза
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Платформа
    /// </summary>
    public List<Platform> Platforms { get; set; }

    /// <summary>
    /// Компания-разработчик
    /// </summary>
    public Company Developer { get; set; }
    
    /// <summary>
    /// Id разработчика
    /// </summary>
    public uint DeveloperId { get; set; }
    
    public List<GameCategory> GameCategories { get; set; }
    
    public List<GamePlatform> GamePlatforms { get; set; }
}