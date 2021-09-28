using Landinfo.DAL.Data;
using Landinfo.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landinfo.Services.Services
{
    public interface IPropertyInfoService
    {
        public Task<List<PropertyInfo>> GetAllPropertyInfos();
        public Task<List<State>> GetStatesByCountryId(int id);
    }
    public class PropertyInfoService : IPropertyInfoService
    {
        public async Task<List<PropertyInfo>> GetAllPropertyInfos()
        {
            using (var Context = new LandinfoDbContext())
            {
                var landinfoDbContext = Context.PropertyInfos.Include(p => p.Company).Include(p => p.Field).Include(p => p.OperatingArea).Include(p => p.Property);
                return await landinfoDbContext.ToListAsync();
            };
        }

        public async Task<List<State>> GetStatesByCountryId(int id)
        {
            using (var Context = new LandinfoDbContext())
            {
                var stateContext = Context.States.Where(c => c.CountryId == id);
                return await stateContext.ToListAsync();
            };
        }
    }
}
