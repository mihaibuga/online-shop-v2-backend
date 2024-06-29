using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Interfaces.Files;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories
{
    public class AppFileRepository : IAppFileRepository
    {
        private readonly ApplicationDbContext _context;

        public AppFileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppFile> CreateAsync(AppFile fileModel)
        {
            await _context.AppFiles.AddAsync(fileModel);
            await _context.SaveChangesAsync();
            return fileModel;
        }

        public async Task<AppFile?> DeleteAsync(Guid id)
        {
            var existingAppFile = await _context.AppFiles
                    .FirstOrDefaultAsync(appFile => appFile.Id == id);

            if (existingAppFile == null)
            {
                return null;
            }

            _context.AppFiles.Remove(existingAppFile);
            await _context.SaveChangesAsync();

            return existingAppFile;
        }

        public async Task<PagedResponse<IQueryable<AppFile>>> GetAllAsync(QueryObject query)
        {
            var appFiles = _context.AppFiles.AsQueryable();

            appFiles.OrderByDescending(f => f.CreatedDate);

            //Paginate files
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var pagedFiles = appFiles.Skip(skipNumber).Take(query.PageSize);

            //Create paginated response
            var response = new PagedResponse<IQueryable<AppFile>>(pagedFiles, query.PageNumber, query.PageSize);

            var totalProducts = await _context.AppFiles.CountAsync();
            response.TotalRecords = totalProducts;

            var totalPages = ((double)totalProducts / (double)query.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.TotalPages = roundedTotalPages;

            response.IsNextPage = response.PageNumber >= 1 && response.PageNumber < roundedTotalPages;
            response.IsPreviousPage = response.PageNumber - 1 >= 1 && response.PageNumber <= roundedTotalPages;

            return response;
        }

        public async Task<AppFile?> GetByIdAsync(Guid id)
        {
            return await _context.AppFiles
                    .FirstOrDefaultAsync(appFile => appFile.Id == id);
        }

        public Task<AppFile> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
