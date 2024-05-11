using TeamHost.Models;

namespace TeamHost.Interfaces;

public interface IStoreService
{
    /// <summary>
    /// Получение всех игр в магазине
    /// </summary>
    /// <returns>Список игр в магазине</returns>
    Task<GameResponse[]> GetAllGames();

    /// <summary>
    /// Получение игры по ID
    /// </summary>
    /// <param name="id">ID игры</param>
    /// <returns>Игра</returns>
    GameResponse GetGameById(uint id);
}