using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class EfMediaTypeRepository : IMediaTypeRepository
    {
        private AppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public EfMediaTypeRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor) 
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        MediaType IMediaTypeRepository.CreateMediaType(MediaType mediaType)
        {
            context.MediaTypes.Add(mediaType);
            context.SaveChanges();
            return mediaType;
        }

        IQueryable<MediaType> IMediaTypeRepository.GetUserMediaTypes(IEnumerable<MediaEntry> mediaEntries)
        {
            IQueryable<MediaType> mediaTypes = context.MediaTypes.Where(mt => mt.Id.Equals(mediaEntries.Select(me => me.MediaTypeId)));
            return mediaTypes;
        }

        MediaType IMediaTypeRepository.GetMediaTypeById(int mediaTypeId) 
        {
            return context.MediaTypes
                          .Where(mt => mt.Id == mediaTypeId)
                          .FirstOrDefault();
        }

        int IMediaTypeRepository.GetLoggedUser()
        {
            if (httpContextAccessor.HttpContext.Session.GetInt32("_UserId") != null)
            {
                return (int)httpContextAccessor.HttpContext.Session.GetInt32("_UserId");
            }
            return 0;
        }

        MediaType IMediaTypeRepository.UpdateMediaType(MediaType mediaType)
        {
            MediaType entryToUpdate = context.MediaTypes.SingleOrDefault(mt => mt.Id == mediaType.Id);
            if (entryToUpdate != null)
            {
                entryToUpdate.Name = mediaType.Name;
                context.SaveChanges();
            }
            return mediaType;
        }

        bool IMediaTypeRepository.DeleteMediaType(int mediaTypeId)
        {
            MediaType entryToDelete = context.MediaTypes.FirstOrDefault(mt => mt.Id == mediaTypeId);
            if (entryToDelete != null) 
            {
                context.MediaTypes.Remove(entryToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
