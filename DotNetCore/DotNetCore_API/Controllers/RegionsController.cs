using AutoMapper;
using DotNetCore_API.CustomActionFilters;
using DotNetCore_API.Data;
using DotNetCore_API.Models.Domain;
using DotNetCore_API.Models.DTO;
using DotNetCore_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DotNetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   

    
    public class RegionsController : ControllerBase
    {

        private readonly DotNetCoreDbcontext _dbcontext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionsController> _logger;

        public RegionsController(DotNetCoreDbcontext dbcontext , IRegionRepository regionRepository , IMapper mapper  , ILogger<RegionsController> logger)
        {
            _dbcontext = dbcontext;
            _regionRepository = regionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public DotNetCoreDbcontext Dbcontext { get; set; }
        public IRegionRepository RegionRepository { get; }

        [HttpGet]
       // [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {

            
                var regionsDomain = await _regionRepository.GetAllAsync();

                _logger.LogInformation($"Finished Region with data :{JsonSerializer.Serialize(regionsDomain)}");

                return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
            

           
           
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            //var regions = _dbcontext.Regions.Find(id);
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<RegionDto>>(regionDomain));
        }

        [HttpPost]
        [ValidateModelAttributes]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
              var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult>  Update( Guid id, [FromBody]UpdateRegionRequestDTO updateRegionRequestDTO )

        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDTO);
        

            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)

                    { return NotFound();  }
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            
            return Ok(regionDto);

         }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ValidateModelAttributes]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));


        }
    }
}
