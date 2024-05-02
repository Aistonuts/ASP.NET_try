﻿namespace MagicCardsmith.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MagicCardsmith.Web.ViewModels.Card;

    public interface ICardService
    {
        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        T GetById<T>(int id);

        int GetCount();

        IEnumerable<T> GetRandom<T>(int count);

        IEnumerable<T> GetAllByCardId<T>(int id);

        Task CreateAsync(CreateCardInputModel input, string userId, int id, string path, bool isEventCard, bool requireArtInput,string canvasCapture);

        IEnumerable<T> GetByTypeCards<T>(IEnumerable<int> cardTypeId);

        IEnumerable<T> GetAllTypes<T>();

        IEnumerable<T> GetByName<T>(string name);

        IEnumerable<T> GetAllCardsByExpansionId<T>(int id);

        IEnumerable<T> GetAllByUserId<T>(string id, int page, int itemsPerPage = 12);

        Task UpdateAsync(int id, BaseCreateCardInputModel input);

        Task ApproveCard(int id);
    }
}
