using Microsoft.EntityFrameworkCore;
using ProjectStomatology.Models;
using ProjectStomatology.Repository.InterfaceRepository;

namespace ProjectStomatology.Repository
{
    public class RclientRepository : IRclient<Rclient>
    {
        StomatologyContext db;

        public RclientRepository(StomatologyContext db)
        {
            this.db = db;

        }

        public void Create(Rclient rclient)
        {
            try
            {
                if (rclient != null)
                {
                    db.Rclients.Add(rclient);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<Rclient> Delete(int id)
        {
            try
            {
                if (db != null)
                {
                    Rclient rclient = await db.Rclients.FirstOrDefaultAsync(x => x.Id == id);
                    return rclient;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }

        public IEnumerable<Rclient> GetAll()
        {
            return db.Rclients.ToList();
        }




        public async Task<Rclient> Details(int id)
        {
            try
            {
                if (id != null)
                {
                    Rclient rclientclient = db.Rclients.FirstOrDefault(x => x.Id == id);
                    return rclientclient;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }



        public Rclient Edit(int id)
        {
            try
            {
                if (id != null)
                {
                    Rclient rclient = db.Rclients.FirstOrDefault(x => x.Id == id);
                    return rclient;

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }


    }




}
