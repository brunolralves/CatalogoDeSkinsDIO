using CatalogoDeSkinsDIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Repository
{
    public interface ISkinRepository : IDisposable
    {
        Task<List<Skin>> Get(int page, int quantity);

        Task<Skin> Get(Guid id);

        Task<List<Skin>> Get(string name, string packageName);

        Task Post(Skin skin);

        Task Update(Skin skin);

        Task Remove(Guid id);

    }
}
