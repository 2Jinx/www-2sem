namespace TeamHost.Entities;

/// <summary>
/// Разработчик
/// </summary>
public class Company
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
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Id страны
    /// </summary>
    public uint CountryId { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public Country Country { get; set; }
}