using Dapper;
using Dapper.Contrib.Extensions;
using Dominio.Entidad.Entity;
using Dominio.Interface.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Dominio.Infraestructura.Repositories
{
    public class LibrosRepository : ILibrosRepository
    {
        private readonly IConfiguration _configuration;
        public LibrosRepository(IConfiguration configuration) { _configuration = configuration; }

        public async Task<int> ActualizarLibroAsycn(Libros entity)
        {

            //DataTableMapping table = []
            // Colocamos la instruccion SQL
            var response = default(int);
            var sql = "[dbo].[SP_EDITA_LIBRO]";

            // Aqui va la conexion de acuerdo a nuestro appsetings
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

             
                DynamicParameters dynamicparams = new DynamicParameters();
                dynamicparams.Add("@nom_libro", entity.nom_libro, DbType.String, ParameterDirection.Input);
                dynamicparams.Add("@autor_libro", entity.autor_libro, DbType.String, ParameterDirection.Input);
                dynamicparams.Add("@categoria", entity.categoria, DbType.String, ParameterDirection.Input);
                dynamicparams.Add("@fecha_lanzamiento", entity.fecha_lanzamiento, DbType.String, ParameterDirection.Input);
                dynamicparams.Add("@estado", entity.estado, DbType.Int32, ParameterDirection.Input);
                dynamicparams.Add("@id_libro", entity.id_libro, DbType.Int32, ParameterDirection.Input);

                response = await connection.ExecuteAsync(sql, dynamicparams, commandType: CommandType.StoredProcedure);

                connection.Close();

                return response;


            }
        }

        public async Task<int> DeleteLibroAsycn(int id)
        {
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "[dbo].[SP_ELIMINA_LIBRO]";
                connection.Open();

                DynamicParameters dynamicparams = new DynamicParameters();
                dynamicparams.Add("@id_libro",id, DbType.Int32, ParameterDirection.Input);
                var elimina = await connection.ExecuteAsync(sql, dynamicparams, commandType: CommandType.StoredProcedure);
                return elimina;
            }
        }

        public async Task<IReadOnlyList<Libros>>  ListaByIdAsycn(int id)
        {
            var sql = "[dbo].[SP_BUSCA_LIBRO]";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
               
                connection.Open();

                DynamicParameters dynamicparams = new DynamicParameters();
                dynamicparams.Add("@id_libro", id, DbType.Int32, ParameterDirection.Input);
                var listall = await connection.QueryAsync<Libros>(sql, dynamicparams, commandType: CommandType.StoredProcedure);
                return listall.ToList();

            }
        }

        public async Task<IReadOnlyList<Libros>> ListTodoAsync()
        {

            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "[dbo].[SP_LISTA_LIBROS]";
                connection.Open();

                //Aqui mapeamos los libros desde la base de datos que definimos en la libreria de clase.
                var listall = await connection.QueryAsync<Libros>(sql,commandType: CommandType.StoredProcedure);
                return listall.ToList();
            }
        }

        public async Task<int> NewLibroAsync(Libros entity)
        {
            //DataTableMapping table = []
            // Colocamos la instruccion SQL
            var response = default(int);
            var sql = "[dbo].[SP_INSERTA_LIBRO]";

            // Aqui va la conexion de acuerdo a nuestro appsetings
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                //// ejectamos la funcion de tipo Async 
                //var insert = await connection.InsertAsync<Libros>(entity);
                //return insert;

                DynamicParameters dynamicparams = new DynamicParameters();
                dynamicparams.Add("@nom_libro",entity.nom_libro,DbType.String,ParameterDirection.Input);
                dynamicparams.Add("@autor_libro", entity.autor_libro, DbType.String, ParameterDirection.Input);
                dynamicparams.Add("@categoria", entity.categoria, DbType.String, ParameterDirection.Input);
                dynamicparams.Add("@fecha_lanzamiento", entity.fecha_lanzamiento, DbType.String, ParameterDirection.Input);

                response = await connection.ExecuteAsync(sql, dynamicparams, commandType:CommandType.StoredProcedure);

                connection.Close();

                return response;

               
            }
        }
    }
}
