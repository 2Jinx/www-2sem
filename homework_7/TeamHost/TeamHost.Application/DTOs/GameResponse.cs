namespace TeamHost.Application.DTOs;

public class GameResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена (в вонах)
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Главное изображение
    /// </summary>
    public string? MainImagePath { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public float Rating { get; set; }

    /// <summary>
    /// Категория
    /// </summary>
    public List<string> Categories { get; set; }

    /// <summary>
    /// Платформа
    /// </summary>
    public List<PlatformResponse> Platforms { get; set; }
    
    public string? Description { get; set; }
    
    public string? Developer { get; set; }
}