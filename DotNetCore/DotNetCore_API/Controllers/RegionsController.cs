using AutoMapper;
using DotNetCore_API.Data;
using DotNetCore_API.Models.Domain;
using DotNetCore_API.Models.DTO;
using DotNetCore_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class RegionsController : ControllerBase
    {

        private readonly DotNetCoreDbcontext _dbcontext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(DotNetCoreDbcontext dbcontext , IRegionRepository regionRepository , IMapper mapper )
        {
            _dbcontext = dbcontext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public DotNetCoreDbcontext Dbcontext { get; set; }
        public IRegionRepository RegionRepository { get; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();

            //var regionsDto = new List<RegionDto>();
            //foreach(var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Name = regionDomain.Name,
            //        Code = regionDomain.Code,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });

            //}

            

            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
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

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
              var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
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
