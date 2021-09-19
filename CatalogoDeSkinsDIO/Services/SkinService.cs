using CatalogoDeSkinsDIO.DTO.InputModel;
using CatalogoDeSkinsDIO.DTO.ViewModel;
using CatalogoDeSkinsDIO.Exceptions;
using CatalogoDeSkinsDIO.Models;
using CatalogoDeSkinsDIO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Services
{
    public class SkinService : ISkinService
    {
        private readonly ISkinRepository _skinRepository;

        public SkinService(ISkinRepository skinRepository )
        {
            _skinRepository = skinRepository;
        }

        public async Task<List<SkinViewModel>> Get(int page, int quantity)
        {
            var skins = await _skinRepository.Get(page, quantity);

            return skins.Select(skin => new SkinViewModel
            {
                Id = skin.Id,
                Name = skin.Name,
                PackageName = skin.PackageName,
                Price = skin.Price
            }).ToList();
        }

        public async Task<SkinViewModel> Get(Guid id)
        {
            var skin = await _skinRepository.Get(id);

            if (skin == null)
                return null;

            return new SkinViewModel
            {
                Id = skin.Id,
                Name = skin.Name,
                PackageName = skin.PackageName,
                Price = skin.Price
            };
        }

        public async Task<SkinViewModel> Post(SkinInputModel skin)
        {
            var modelSkin = await _skinRepository.Get(skin.Name, skin.PackageName);

            if (modelSkin.Count > 0)
                throw new SkinAlreadyRegisteredException();

            var skinPost = new Skin
            {
                Id = Guid.NewGuid(),
                Name = skin.Name,
                PackageName = skin.PackageName,
                Price = skin.Price
            };

            await _skinRepository.Post(skinPost);

            return new SkinViewModel
            {
                Id = skinPost.Id,
                Name = skin.Name,
                PackageName = skin.PackageName,
                Price = skin.Price
            };
        }

        public async Task Update(Guid id, SkinInputModel skin)
        {
            var modelSkin = await _skinRepository.Get(id);

            if (modelSkin == null)
                throw new SkinNotRegisteredException();

            modelSkin.Name = skin.Name;
            modelSkin.PackageName = skin.PackageName;
            modelSkin.Price = skin.Price;

            await _skinRepository.Update(modelSkin);
        }

        public async Task Update(Guid id, double price)
        {
            var modelSkin = await _skinRepository.Get(id);

            if (modelSkin == null)
                throw new SkinNotRegisteredException();

            modelSkin.Price = price;

            await _skinRepository.Update(modelSkin);
        }

        public async Task Remove(Guid id)
        {
            var skin = await _skinRepository.Get(id);

            if (skin == null)
                throw new SkinNotRegisteredException();

            await _skinRepository.Remove(id);
        }

        public void Dispose()
        {
            _skinRepository?.Dispose();
        }

       
    }
}
