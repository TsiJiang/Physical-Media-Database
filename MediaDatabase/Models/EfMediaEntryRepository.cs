using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class EfMediaEntryRepository : IMediaEntryRepository
    {
        private AppDbContext context;
        public EfMediaEntryRepository(AppDbContext context) 
        {
            this.context = context;
        }
        MediaEntry IMediaEntryRepository.Create(MediaEntry mediaEntry)
        {
            context.MediaEntries.Add(mediaEntry);
            context.SaveChanges();
            return mediaEntry;
        }
        IQueryable<MediaEntry> IMediaEntryRepository.GetAllMediaEntries(int userId)
        {
            return context.MediaEntries
                    .Where(me => me.UserId == userId);
        }

        MediaEntry IMediaEntryRepository.GetMediaEntryById(int MediaEntryId)
        {
            return context.MediaEntries
                    .Where(me => me.Id == MediaEntryId)
                    .FirstOrDefault();
        }

        IQueryable<MediaEntry> IMediaEntryRepository.GetMediaEntriesByKeyword(string keyword, int userId)
        {
            return context.MediaEntries
                    .Where(me => me.Name.Contains(keyword) && me.UserId ==userId);
        }

        MediaEntry IMediaEntryRepository.UpdateMediaEntry(MediaEntry mediaEntry)
        {
            MediaEntry entryToUpdate = context.MediaEntries.SingleOrDefault(me => me.Id == mediaEntry.Id);
            if(entryToUpdate != null) 
            {
                entryToUpdate.Name = mediaEntry.Name;
                entryToUpdate.LastModified = mediaEntry.LastModified;
                entryToUpdate.Size = mediaEntry.Size;
                entryToUpdate.SizeType = mediaEntry.SizeType;
                context.SaveChanges();
            }
            return entryToUpdate;
        }
        bool IMediaEntryRepository.DeleteMediaEntry(int id)
        {
            MediaEntry entryToDelete = context.MediaEntries.FirstOrDefault(me => me.Id == id);
            if (entryToDelete == null) 
            {
                return false;
            }
            context.MediaEntries.Remove(entryToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
