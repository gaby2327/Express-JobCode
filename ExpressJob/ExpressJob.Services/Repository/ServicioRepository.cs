﻿using ExpressJob.Data;
using ExpressJob.Domain;
using ExpressJob.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressJob.Services.Repository
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly ExpressJobContext _context = null;

        public ServicioRepository(ExpressJobContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetAllServicio()
        {
            return await _context.Servicios.Select(x => new Servicio()
            {
                IdServicio = x.IdServicio,
                NombreServicio = x.NombreServicio
            }).ToListAsync();
        }
        
        
        public async Task<int> AddServico(TrabajadorServicio trabajadorServicio)
        {
            var newServicio = new TrabajadorServicio()
            {
                TrabajadorId = trabajadorServicio.TrabajadorId,
                ServicioId = trabajadorServicio.ServicioId,
                Descripcion = trabajadorServicio.Descripcion
                
            };
            await _context.TrabajadorServicios.AddAsync(newServicio);
            await _context.SaveChangesAsync();

            return newServicio.TrabajadorId;
        }
      

       
    }
}
