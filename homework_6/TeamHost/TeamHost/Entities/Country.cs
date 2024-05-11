namespace TeamHost.Entities;

/// <summary>
/// Страна
/// </summary>
public class Country
{
    /// <summary>
    /// Id
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// числовой код страны
    /// </summary>
    public uint Code { get; set; }

    /// <summary>
    /// короткое название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// полное название страны
    /// </summary>
    public string Fullname { get; set; }

    /// <summary>
    /// 2х-буквенный код
    /// </summary>
    public string Alpha2 { get; set; }

    /// <summary>
    /// 3х-буквенный код
    /// </summary>
    public string Alpha3 { get; set; }

    public Country(){}

    public Country(uint id, uint code, string name, string fullname, string alpha2 , string alpha3) {
        Id = id;
        Code = code;
        Name = name;
        Fullname = fullname;
        Alpha2 = alpha2;
        Alpha3 = alpha3;
    }
}