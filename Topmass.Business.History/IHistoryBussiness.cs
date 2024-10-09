﻿using Topmass.Business.History.model;

namespace Topmass.Business.History
{
    public interface IHistoryBussiness
    {
        public Task<HIstoryDataReponse> GetAccessLog(int userId, int source = 2, int typedata = 1);
        public Task<bool> Add(HIstoryDataRequestAdd request);
    }
}
