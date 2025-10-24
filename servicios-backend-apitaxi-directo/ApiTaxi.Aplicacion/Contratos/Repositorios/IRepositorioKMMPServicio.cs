using ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTaxi.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioKMMPServicio
    {
        Task<KmmpEstadosResponseDto> ObtenerEstadosPush();
    }
}
