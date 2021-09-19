using CatalogoDeSkinsDIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Repository
{
    public class SkinRepository : ISkinRepository
    {
        private static Dictionary<Guid, Skin> skins = new Dictionary<Guid, Skin>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Skin{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Name = "Vandal GlitchPop", PackageName = "GlitchPop", Price = 2275} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Skin{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Name = "Vandal Elderflame", PackageName = "Elderflame ", Price = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Skin{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Name = "Spectre Sublime", PackageName = "Sublime", Price = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Skin{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Name = "Classic Sublime", PackageName = "Sublime", Price = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Skin{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Name = "Blade of the Ruined King", PackageName = "Ruined", Price = 4350} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Skin{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Name = "Ion Energy", PackageName = "Ion", Price = 190} }
        };

        public Task<List<Skin>> Get(int page, int quantity)
        {
            return Task.FromResult(skins.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<Skin> Get(Guid id)
        {
            if (!skins.ContainsKey(id))
                return Task.FromResult<Skin>(null);

            return Task.FromResult(skins[id]);
        }

        public Task<List<Skin>> Get(string name, string packageName)
        {
            return Task.FromResult(skins.Values.Where(skin => skin.Name.Equals(name) && skin.PackageName.Equals(packageName)).ToList());
        }
                

        public Task Post(Skin skin)
        {
            skins.Add(skin.Id, skin);
            return Task.CompletedTask;
        }

        public Task Update(Skin skin)
        {
            skins[skin.Id] = skin;
            return Task.CompletedTask;
        }

        public Task Remove(Guid id)
        {
            skins.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }

    }
}
