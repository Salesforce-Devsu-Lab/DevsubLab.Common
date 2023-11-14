using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetCoreForce.Client;


namespace Devsulab.Common.SalesForce
{
    public class SalesForceRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly ForceClient forceClient;
        
        public SalesForceRepository(ForceClient client)
        {
            forceClient = client;
        }
        
        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await forceClient.CreateRecord(typeof(T).Name, entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await forceClient.GetObjectById<T>(typeof(T).Name, id.ToString());
        }
    }
}