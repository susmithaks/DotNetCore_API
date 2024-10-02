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

        public async Task<List<Walk>> GetAllAsync()
        {
             return  await _dbcontext.Walks.Include("Difficulty").Include("Region").ToListAsync();

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

