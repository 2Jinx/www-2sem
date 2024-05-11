using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Файл
/// </summary>
public class StaticFile: IEntity
{
    /// <summary>
    /// Id 
    /// </summary>
    public uint Id { get; set; }
    
    /// <summary>
    /// Путь
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Размер в КБ
    /// </summary>
    public int? Size { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Расширение
    /// </summary>
    public string? Extension { get; private set; }
    
    public StaticFile(string path, string name)
    {
        Path = path;
        Name = name;
        Extension = name.Split('.').LastOrDefault();
    }

    public StaticFile() { }
}