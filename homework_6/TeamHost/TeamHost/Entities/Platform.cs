namespace TeamHost.Entities;

/// <summary>
/// Платформа
/// </summary>
public class Platform
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
    /// Код
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Изображение
    /// </summary>
    public StaticFile? Image { get; set; }

    public List<Game> Games { get; set; }
}