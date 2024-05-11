using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Категория
/// </summary>
public class Category: IEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public uint Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Код
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    public List<GameCategory> GameCategories { get; set; }
}