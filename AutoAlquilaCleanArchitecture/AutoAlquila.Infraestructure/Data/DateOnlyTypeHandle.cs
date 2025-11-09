using Dapper;
using System.Data;

namespace AutoAlquila.Infraestructure.Data
{
    //ESTO ES DEBIDO A QUE EN LA ENTIDADES SE MANEJO PROPIEDADES DE TIPO DATEONLY Y PARA EL MOTOR
    //DE LA BASE DE DATOS NO EXISTE, POR ESO DE DEBE PARSEARSE DATEONLY => DATETIME
    internal sealed class DateOnlyTypeHandle : SqlMapper.TypeHandler<DateOnly>
    {
        public override DateOnly Parse(object value) => DateOnly.FromDateTime((DateTime)value);

        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value;    
        }
    }
}
