using Microsoft.EntityFrameworkCore;
using ProjectStomatology.Models;
using ProjectStomatology.Repository.InterfaceRepository;

namespace ProjectStomatology.Repository
{
    public class JdiseaseHistoryRepository : JdiseaseHistory<JdiseaseHistory>
    {
        StomatologyContext db;

        public JdiseaseHistoryRepository(StomatologyContext db)
        {
            this.db = db;

        }

        public void Create(JdiseaseHistory history)
        {
            try
            {
                if (history != null)
                {
                    db.JdiseaseHistories.Add(history);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<JdiseaseHistory> Delete(int id)
        {
            try
            {
                if (db != null)
                {
                    JdiseaseHistory jdisease = await db.JdiseaseHistories.FirstOrDefaultAsync(x => x.Id == id);
                    return jdisease;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }

        public IEnumerable<JdiseaseHistory> GetAll()
        {
            return db.JdiseaseHistories.ToList();
        }




        public async Task<JdiseaseHistory> Details(int id)
        {
            try
            {
                if (id != null)
                {
                    JdiseaseHistory jdisease = db.JdiseaseHistories.FirstOrDefault(x => x.Id == id);
                    return jdisease;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }



        public JdiseaseHistory Edit(int id)
        {
            try
            {
                if (id != null)
                {
                    JdiseaseHistory jdisease = db.JdiseaseHistories.FirstOrDefault(x => x.Id == id);
                    return jdisease;

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }
    }
}
