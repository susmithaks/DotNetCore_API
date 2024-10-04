using AutoMapper;
using DotNetCore_API.Models.Domain;
using DotNetCore_API.Models.DTO;
using DotNetCore_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
           _mapper = mapper;
            _walkRepository = walkRepository;
        }    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           var walkDomainModel =_mapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(walkDomainModel);
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }


        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? filrerOn , [FromQuery] string? filterQuery , [FromQuery] string? sortyBy,
            [FromQuery] bool? isAscending , [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
           var walksDomainModel= await _walkRepository.GetAllAsync(filrerOn, filterQuery, sortyBy, isAscending ?? true, pageNumber,pageSize);
            throw new Exception("this is a new exceprion");
            return Ok(_mapper.Map<List<WalkDTO>>(walksDomainModel));
        }
        [HttpGet]
        [Route ("{id:Guid}")]
        public async Task<IActionResult> GetById ([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id , UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel= await _walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel== null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var DeletedWalkDomainModel = await _walkRepository.DeleteAsync(id);
            if (DeletedWalkDomainModel == null)
            {
                return NotFound();

            }
            return Ok(_mapper.Map<WalkDTO>(DeletedWalkDomainModel));
        }
    }
}
