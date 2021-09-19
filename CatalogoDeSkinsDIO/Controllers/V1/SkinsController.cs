using CatalogoDeSkinsDIO.DTO.InputModel;
using CatalogoDeSkinsDIO.DTO.ViewModel;
using CatalogoDeSkinsDIO.Exceptions;
using CatalogoDeSkinsDIO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class SkinsController : ControllerBase
    {
        private readonly ISkinService _skinService;

        public SkinsController(ISkinService skinService)
        {
            _skinService = skinService;
        }


        //Busca todas as skins fazendo paginação
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkinViewModel>>> Get([FromQuery,Range(1,int.MaxValue)] int page = 1, [FromQuery, Range(1,50)] int quantity=5)
        {

            var skins = await _skinService.Get(page, quantity);

            //Se não encontrar retorna 204
            if (skins.Count() == 0)
                return NoContent();

            //Caso encontre retorna a skin + status 200
            return Ok(skins);
               
        }
        

        //Buscar apenas uma skin
        [HttpGet("{idSkin:guid}")]
        public async Task<ActionResult<SkinViewModel>> Get([FromRoute]Guid idSkin)
        {
            var skin = await _skinService.Get(idSkin);

            //Se não encontrar retorna 204
            if (skin == null)
                return NoContent();


            //Caso encontre retorna a skin + status 200
            return Ok(skin);
               
        }



        [HttpPost]
        public async Task<ActionResult<SkinViewModel>> PostSkin([FromBody]SkinInputModel skinInputModel)
        {
            try
            {
                var skin = await _skinService.Post(skinInputModel);

                return Ok(skin);
            }
            catch(SkinAlreadyRegisteredException)            
            {
                return UnprocessableEntity("Já existe uma skin cadastrada com este nome para esse pacote");

            }

           
        }


        [HttpPut("{idSkin:guid}")]
        public async Task<ActionResult> UpdateSkin([FromRoute]Guid idSkin,[FromBody] SkinInputModel skinInputModel)
        {

            try
            {
                await _skinService.Update(idSkin, skinInputModel);

                return Ok();
            }
            catch (SkinNotRegisteredException )            
            {

                return NotFound("Essa Skin ainda não existe");
            }
            
        }
        
        
        [HttpPatch("{idSkin:guid}/price/{price:double}")]
        public async Task<ActionResult> UpdateSkin([FromRoute] Guid idSkin,[FromRoute]double price)
        {
            try
            {
                await _skinService.Update(idSkin, price);
                return Ok();
            }
            catch (SkinNotRegisteredException)          
            {

                return NotFound("Essa Skin ainda não existe");
            }
            
        }


        [HttpDelete("{idSkin:guid}")]
        public async Task<ActionResult> DeleteSkin([FromRoute] Guid idSkin)
        {
            try
            {
                await _skinService.Remove(idSkin);
                return Ok();
            }
            catch (SkinNotRegisteredException)            
            {

                return NotFound("Essa Skin ainda não existe");
            }

           
        }

        
    }
}
