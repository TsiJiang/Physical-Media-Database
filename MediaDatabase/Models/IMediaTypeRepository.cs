using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public interface IMediaTypeRepository
    {
        MediaType CreateMediaType(MediaType mediaType);
        IQueryable<MediaType> GetUserMediaTypes(IEnumerable<MediaEntry> mediaEntries);
        MediaType GetMediaTypeById(int mediaTypeId);
        int GetLoggedUser();
        MediaType UpdateMediaType(MediaType mediaType);
        bool DeleteMediaType(int mediaTypeId);
    }
}
