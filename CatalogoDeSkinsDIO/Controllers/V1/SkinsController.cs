using CatalogoDeSkinsDIO.DTO.InputModel;
using CatalogoDeSkinsDIO.DTO.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class SkinsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SkinViewModel>>> Get()
        {
            return Ok();
               
        }
        

        //Buscar apenas uma skin
        [HttpGet("{idSkin")]
        public async Task<ActionResult<SkinViewModel>> Get(Guid idSkin)
        {
            return Ok();
               
        }



        [HttpPost]
        public async Task<ActionResult<SkinViewModel>> PostSkin(SkinInputModel skin)
        {
            return Ok();
        }


        [HttpPut("{idSkin:guid}")]
        public async Task<ActionResult> UpdateSkin(Guid idSkin, SkinInputModel skin)
        {
            return Ok();
        }
        
        
        [HttpPatch("{idSkin:guid}/price/{price:double}")]
        public async Task<ActionResult> UpdateSkin(Guid idSkin,double price)
        {
            return Ok();
        }


        [HttpDelete("{idSkin:guid}")]
        public async Task<ActionResult> DeleteSkin(Guid idSkin)
        {
            return Ok();
        }
    }
}
