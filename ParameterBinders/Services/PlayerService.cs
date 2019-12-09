using Microsoft.EntityFrameworkCore;
using ParameterBinders.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParameterBinders.Services
{

    public interface IService<T> where T: class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<T> PostAsync(T data);
    }

    public class PlayerService : IService<Player>
    {
        private readonly PlayerContext context;
        public PlayerService(PlayerContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Player>> GetAsync()
        {
            return await context.Players.ToListAsync();
        }

        public async Task<Player> GetAsync(int id)
        {
            return await context.Players.FindAsync(id);
        }

        public async Task<Player> PostAsync(Player data)
        {
            try
            {
                var res =  await context.Players.AddAsync(data);
                await context.SaveChangesAsync();
                return res.Entity;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
