﻿namespace MagicCardsmith.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MagicCardsmith.Web.ViewModels.Event;

    public interface IStoreService
    {
        IEnumerable<T> GetAll<T>();

        Task CreateAsync(SingleEventViewModel input, string storeOwner, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        T GetById<T>(int id);

        int GetCount();

        IEnumerable<T> GetAllByUserId<T>(string id, int page, int itemsPerPage = 3);

        Task ApproveStore(int id);
    }
}
