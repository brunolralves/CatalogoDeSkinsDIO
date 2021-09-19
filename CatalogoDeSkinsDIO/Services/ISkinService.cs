using CatalogoDeSkinsDIO.DTO.InputModel;
using CatalogoDeSkinsDIO.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Services
{
    public interface ISkinService : IDisposable
    {
        Task<List<SkinViewModel>> Get(int page, int quantity);

        Task<SkinViewModel> Get(Guid id);

        Task<SkinViewModel> Post(SkinInputModel skin);

        Task Update(Guid id, SkinInputModel skin);

        Task Update(Guid id, double price);


        Task Remove(Guid id);


        
    }
}
