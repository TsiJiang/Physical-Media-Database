using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public interface IMediaEntryRepository
    {
        //   C r e a t e
        MediaEntry Create(MediaEntry mediaEntry);
        //   R e a d
        IQueryable<MediaEntry> GetAllMediaEntries(int userId);
        MediaEntry GetMediaEntryById(int MediaEntryId);
        IQueryable<MediaEntry> GetMediaEntriesByKeyword(string keyword, int userId);
        int GetLoggedUser();
        //   U p d a t e
        MediaEntry UpdateMediaEntry(MediaEntry mediaEntry);
        //   D e l e t e
        bool DeleteMediaEntry(int id);
    }
}
