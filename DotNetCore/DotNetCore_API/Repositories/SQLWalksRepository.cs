using DotNetCore_API.Data;
using DotNetCore_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_API.Repositories
{
    public class SqlWalksRepository : IWalkRepository
    {
        private readonly DotNetCoreDbcontext _dbcontext;

        public SqlWalksRepository(DotNetCoreDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public  async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbcontext.Walks.AddAsync(walk);
            await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
           var existingWalk = await _dbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            _dbcontext.Walks.Remove(existingWalk);
            await _dbcontext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortyBy = null, bool isAscending = true,
           int  pageNumber = 1 , int PageSize = 1000)
        {
            var walks = _dbcontext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //filteringif 

            if (string.IsNullOrWhiteSpace(filterOn)== false && string.IsNullOrWhiteSpace(filterQuery)== false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //sorting 

            if(string.IsNullOrWhiteSpace(sortyBy)== false)
            {
                if(sortyBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
            }
            var skipResults = (pageNumber - 1) * PageSize;
            return await walks.Skip(skipResults).Take(PageSize).ToListAsync();

            //return  await _dbcontext.Walks.Include("Difficulty").Include("Region").ToListAsync();

        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
           return await _dbcontext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.Description = walk.Description;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;
            await _dbcontext.SaveChangesAsync();
            return existingWalk;
        }
    }
    }

