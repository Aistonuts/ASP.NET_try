﻿namespace Wizzarts.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wizzarts.Web.ViewModels.Event;

    public interface IAdminEventService
    {
        Task CreateAsync(CreateEventViewModel input, string userId, string imagePath, bool isContentCreator);

        Task UpdateAsync(EditEventViewModel input, int id);

        Task<IEnumerable<T>> GetAll<T>(int page, int itemsPerPage = 3);

        Task<IEnumerable<T>> GetAllPaginationless<T>();

        Task<IEnumerable<T>> GetAllEventComponents<T>(int id);

        Task<T> GetById<T>(int id);

        Task<T> GetEventComponentById<T>(int id);

        Task<IEnumerable<T>> GetAllEventsByUserIdPageless<T>(string id);

        Task<IEnumerable<T>> GetAllEventsByUserId<T>(string id, int page, int itemsPerPage = 3);

        Task<bool> EventExist(int id);

        Task<bool> EventComponentExist(int id);

        Task<bool> HasUserWithIdAsync(int articleId, string userId);

        Task DeleteAsync(int id);

        Task<string> ApproveEvent(int id);

        Task AddComponentAsync(MyEventSettingsViewModel input, string userId, string imagePath);

        Task DeleteComponentAsync(int id);

        Task<IEnumerable<T>> GetAllTagHelpControllers<T>();

        Task<IEnumerable<T>> GetAllTagHelpActions<T>();

        Task<IEnumerable<T>> GetAllEventCategories<T>();

        Task<bool> EventCategoryExist(int id);

        Task<bool> EventTypeRequireArt(int id);

        Task<string> PromoteEvent(int id);

        Task<int> GetCount();
    }
}
