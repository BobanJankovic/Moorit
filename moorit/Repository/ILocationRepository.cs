﻿using Moorit.Models;

namespace Moorit.Repository
{
    public interface ILocationRepository
    {
        Task<List<LocationModel>> GetAllLocationsAsync();
        Task<LocationModel> GetLocationByIdAsync(int locationId);
        Task<int> AddLocationAsync(LocationModel locationModel);

        Task PutUpdateLocationAsync(int locationId, LocationModel locationModel);

        Task DeleteLocationAsync(int Id);
    }
}
