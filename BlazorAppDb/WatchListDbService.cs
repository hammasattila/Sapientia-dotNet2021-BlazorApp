using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorAppDb
{
    public class WatchListDbService
    {
        public bool InWatchList(int movieId)
        {
            using (var db = new SQLiteDbContext())
            {
                return db.WatchList.Any(x => x.MovieId == movieId);
            }
        }

        public bool TryAdd(WatchListItem watchlist)
        {
            if (InWatchList(watchlist.MovieId))
            {
                return false;
            }

            using (var db = new SQLiteDbContext())
            {
                db.WatchList.Add(watchlist);
                db.SaveChanges();
            }

            return true;
        }

        public bool Delet(int movieId)
        {
            using (var db = new SQLiteDbContext())
            {
                var item = db.WatchList.FirstOrDefault(x => x.MovieId == movieId);
                if(item != null)
                {
                    db.WatchList.Remove(item);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public List<WatchListItem> Get()
        {
            using (var db = new SQLiteDbContext())
            {
                return db.WatchList.ToList();
            }
        }
    }
}
