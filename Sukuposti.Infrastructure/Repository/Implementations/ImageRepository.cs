using System.Net.Mime;
using Sukuposti.Infrastructure.Context;
using Sukuposti.Infrastructure.Models;
using Sukuposti.Infrastructure.Repository.BaseRepository;
using Sukuposti.Infrastructure.Repository.Interfaces;

namespace Sukuposti.Infrastructure.Repository.Repositories;

public class ImageRepository : BaseRepository<HevonenKuva>, IImageRepository 
{
    public ImageRepository(ApiContext context) : base(context)
    {
    }
}