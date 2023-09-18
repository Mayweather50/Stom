using Microsoft.EntityFrameworkCore;
using ProjectStomatology.Models;
using ProjectStomatology.Repository.InterfaceRepository;

namespace ProjectStomatology.Repository
{
    public class VisitHistoryRepository : IVisitHistory<VisitHistory>
    {
        StomatologyContext db;

        public VisitHistoryRepository(StomatologyContext db)
        {
            this.db = db;

        }

        public void Create(VisitHistory history)
        {
            try
            {
                if (history != null)
                {
                    db.VisitHistories.Add(history);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<VisitHistory> Delete(int id)
        {
            try
            {
                if (db != null)
                {
                    VisitHistory visitHistory = await db.VisitHistories.FirstOrDefaultAsync(x => x.Id == id);
                    return visitHistory;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }

        public IEnumerable<VisitHistory> GetAll()
        {
            return db.VisitHistories.ToList();
        }




        public async Task<VisitHistory> Details(int id)
        {
            try
            {
                if (id != null)
                {
                    VisitHistory visitHistory = db.VisitHistories.FirstOrDefault(x => x.Id == id);
                    return visitHistory;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }



        public VisitHistory Edit(int id)
        {
            try
            {
                if (id != null)
                {
                    VisitHistory visitHistory = db.VisitHistories.FirstOrDefault(x => x.Id == id);
                    return visitHistory;

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }


    }
}
